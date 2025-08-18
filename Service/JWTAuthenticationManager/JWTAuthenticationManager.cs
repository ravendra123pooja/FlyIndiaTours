using Azure;
using Azure.Core;
using Dto.Auth;
using Infrastructure.EF.Entity;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.API;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using Utility;
namespace Service.JWTAuthenticationManager
{
    public class JWTAuthenticationManager : BaseService, IJWTAuthenticationManager
    {
        private readonly AppSettings _appSettings;
        private readonly IRefreshTokenGenerator refreshTokenGenerator;
        private readonly IRepository<RefreshToken> _repository;

        public JWTAuthenticationManager(
            IRefreshTokenGenerator refreshTokenGenerator,
            IRepository<RefreshToken> repository,
            IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork) : base(unitOfWork)

        {
            _appSettings = appSettings.Value;
            this.refreshTokenGenerator = refreshTokenGenerator;
            _repository = repository;

        }
        public async Task<AuthenticationResponse> Authenticate(string userName, string deviceSerialNumber, Claim[] claims, string appName = null, string platform = null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings?.SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var jwtSecurityToken = new JwtSecurityToken(
            issuer: _appSettings.Issuer,
            audience: _appSettings.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_appSettings.ExpireTime),
            signingCredentials: credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshTokenValue = refreshTokenGenerator.GenerateToken();
            RefreshToken obj = new RefreshToken();

            var data = await _repository.Entity().Where(x => Equals(x.UserName, userName)).ToListAsync();

            //if (data.Any())
            //{
            //    if (appName != null && data.Where(x => (!string.IsNullOrEmpty(x.AppName) && !string.IsNullOrEmpty(x.AppPlatform)) && (Equals(x.AppName, appName) && Equals(x.AppPlatform,platform))).Any())
            //    {
            //        obj = data.Where(x => Equals(x.AppName, appName) && Equals(x.AppPlatform, platform)).First();
            //    }

            //    else
            //    {
            //        obj = data.First();
            //    }
            //}
            if (data.Count() != 0)
            {
                obj.UserName = userName;
                obj.RefreshTokenValue = refreshTokenValue;
                obj.ModifiedBy = userName;
                obj.ModifiedOn = DateTime.Now;
                obj.IsRevoked = false;
                obj.ExpiredOn = DateTime.Now.AddMinutes(_appSettings.ExpireTime);
                _repository.Update(obj);
                _unitOfWork.Commit();

            }
            else
            {
                RefreshToken refreshToken = new RefreshToken
                {
                    UserName=userName,
                    DeviceSerialNumber = deviceSerialNumber,
                    RefreshTokenValue = refreshTokenValue,
                    
                    IsRevoked = false,
                    CreatedBy= userName.ToUpper(),
                    CreatedOn =DateTime.Now,
                    ExpiredOn = DateTime.Now.AddMinutes(_appSettings.ExpireTime + 1)
                };
                _repository.Insert(refreshToken);
                _unitOfWork.Commit();
            }
            return new AuthenticationResponse
            {
                AccessToken = token,
                RefreshToken = refreshTokenValue,
                ExpireTime = DateTime.Now.AddMinutes(_appSettings.ExpireTime)
            };

        }



        public async Task<APIResponse<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            APIResponse<AuthenticationResponse> aPIResponse = new APIResponse<AuthenticationResponse>();
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings?.SecurityKey));
                var tokenHandler = new JwtSecurityTokenHandler();
                var pricipal = tokenHandler.ValidateToken(refreshTokenDto.AccessToken,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _appSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _appSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateLifetime = false

                }, out SecurityToken validatedToken);
                if (!(validatedToken is JwtSecurityToken jwtToken))
                {
                    throw new SecurityTokenException("Invalid token passed!");

                }

                var obj = await _repository.Entity().FirstOrDefaultAsync(x => Equals(x.UserName, refreshTokenDto.userName)
                                                    && x.RefreshTokenValue == refreshTokenDto.RefreshToken
                                                    && x.IsRevoked == false);


                if (obj != null)
                {
                    AuthenticationResponse authenticationResponse = await Authenticate(refreshTokenDto.userName, Constants.NotApplicable, pricipal.Claims.ToArray());
                    aPIResponse.Message = "Token Refreshed Successfully.";
                    aPIResponse.Success = true;
                    aPIResponse.Data = authenticationResponse;
                    aPIResponse.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    aPIResponse.Message = "Invalid token passed!";
                    aPIResponse.Success = true;
                    aPIResponse.StatusCode = HttpStatusCode.Continue;
                }

                return aPIResponse;

            }
            catch (Exception ex)
            {
                var apicommon = new APIResponse<AuthenticationResponse>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false,
                    Message = ex.Message
                };
                return apicommon;
            }
        }

        private Task<AuthenticationResponse> Authenticate(string userName, object notApplicable, Claim[] claims)
        {
            throw new NotImplementedException();
        }
    }
}
