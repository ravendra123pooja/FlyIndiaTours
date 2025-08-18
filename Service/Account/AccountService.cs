using Dto;
using Dto.Auth;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.API;
using Service.JWTAuthenticationManager;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Utility;

namespace Service.Account
{
    public class AccountService : BaseService, IAccountService
    {

        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISecurityService _securityService;
        private readonly AppSettings _appSetting;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public AccountService(
            FlyIndiaDbContext flyIndiaDbContext,
            ICurrentUserService currentUserService, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            
            IRefreshTokenGenerator refreshTokenGenerator
            , IUnitOfWork unitOfWork, ISecurityService securityService, IOptions<AppSettings> appSettings, IJWTAuthenticationManager jwtAuthenticationManager
            ) : base(unitOfWork)
        {

            _configuration = configuration;
            _currentUserService = currentUserService;
            _httpContextAccessor = httpContextAccessor;
            _flyIndiaDbContext = flyIndiaDbContext;


            _refreshTokenGenerator = refreshTokenGenerator;
            _securityService = securityService;
            _appSetting = appSettings.Value;
            _jwtAuthenticationManager = jwtAuthenticationManager;

        }
        public async Task<APIResponse<UserDto>> Login(LoginModel loginModel)
        {
            APIResponse<UserDto> response = new APIResponse<UserDto>();
            if (loginModel != null)
            {
                try
                {
                    var logindetail = await _flyIndiaDbContext.Usermasters.Where(x => x.UserName == loginModel.UserName).FirstOrDefaultAsync();
                    if (logindetail != null)
                    {
                        if (logindetail.Status == true)
                        {
                            string passwordhashNew = _securityService.GenarateSha256Hash(loginModel.Password, logindetail.SecurityStamp);
                            var userdetail = await _flyIndiaDbContext.Usermasters.Where(x => x.UserName == loginModel.UserName && x.PasswordHash == passwordhashNew).FirstOrDefaultAsync();


                            if (passwordhashNew.ToLower() == logindetail.PasswordHash.ToLower())
                            /// if (userdetail!=null)
                            {
                                string sessionId = _httpContextAccessor?.HttpContext?.Session.Id;
                                var claims = new[] {
                                new Claim(ClaimConstants.SessionId, sessionId),
                                new Claim(ClaimTypes.Name, logindetail.UserName),
                                new Claim(ClaimTypes.NameIdentifier, logindetail.UserName),
                                new Claim(ClaimTypes.Role, Convert.ToString(logindetail.RoleId) ?? string.Empty),
                                new Claim(ClaimConstants.Name, logindetail.Name.ToString()),
                                new Claim(ClaimConstants.UserId, logindetail.Id.ToString()),
                                new Claim(ClaimConstants.RoleId, logindetail.RoleId.ToString()),
                                new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim("LoggedOn", DateTime.Now.ToString()),
                                };
                                AuthenticationResponse authenticationResponse = await _jwtAuthenticationManager.Authenticate(loginModel.UserName, loginModel.MacAddress, claims);

                                if (authenticationResponse == null || string.IsNullOrEmpty(authenticationResponse.AccessToken) || string.IsNullOrEmpty(authenticationResponse.RefreshToken))
                                {
                                    response.Message = "Please Try Again";
                                    response.StatusCode = HttpStatusCode.OK;
                                    response.Success = false;
                                    return response;

                                }
                                var userDto = new UserDto
                                {
                                    SessionId = sessionId,
                                    UserId = logindetail.UserCode,
                                    UserName = logindetail.UserName,
                                    FirstName = logindetail.Name,
                                    AccessToken = authenticationResponse.AccessToken,
                                    RefreshToken = authenticationResponse.RefreshToken,
                                    TokenExpires = authenticationResponse.ExpireTime,
                                    RoleId = Convert.ToString(logindetail.RoleId),
                                };
                                response.Message = "Login Successful";
                                response.StatusCode = HttpStatusCode.OK;
                                response.Data = userDto;
                                response.Success = true;
                                return response;
                            }
                            else
                            {
                                response.Message = "Invalid Password";
                                response.StatusCode = HttpStatusCode.OK;
                                response.Success = false;
                                return response;
                            }
                        }
                        else
                        {
                            response.Message = "You are not authorize please contact to admin";
                            response.StatusCode = HttpStatusCode.OK;
                            response.Success = false;
                            return response;
                        }
                    }
                    else
                    {
                        response.Message = "Invailid username or password";
                        response.StatusCode = HttpStatusCode.OK;
                        response.Success = false;
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    LogInfo.WriteErrorLog("Account_error", "Login", "Login",ex);
                    response.Message = ex.Message;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Success = false;
                    return response;
                }
            }
            else
            {
                response.Message = "Invailid username or password";
                response.StatusCode = HttpStatusCode.OK;
                response.Success = false;
                return response;
            }
        }
    }
}
