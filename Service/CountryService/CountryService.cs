using Dto.Auth;
using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Model.API;
using Service.Account;
using Service.JWTAuthenticationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Microsoft.EntityFrameworkCore;
using Azure;

namespace Service.CountryService
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISecurityService _securityService;
        private readonly AppSettings _appSetting;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;
        public CountryService(
            FlyIndiaDbContext flyIndiaDbContext,
            ICurrentUserService currentUserService, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, IRefreshTokenGenerator refreshTokenGenerator
            , IUnitOfWork unitOfWork
            ) : base(unitOfWork)
        {
            _currentUserService = currentUserService;
            _flyIndiaDbContext = flyIndiaDbContext;
        }
       
        public async Task<APIResponse<List<CountryDto>>> Get()
        {
            APIResponse<List<CountryDto>> response = new APIResponse<List<CountryDto>>();
            try
            {
                
                var countryList = await _flyIndiaDbContext.Countries
                  .Where(c => c.Status == true)
                  .Select(c => new CountryDto
                  {
                      Id = c.Id,
                      CountryCode = c.CountryCode,
                      Code = c.Code,
                      CountryName = c.CountryName,
                      Status = c.Status
                  })
                  .ToListAsync();
                response.Message = "Country list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = countryList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Country list fetching issue";
                response.StatusCode = HttpStatusCode.OK;
                
                response.Success = false;
                return response;
                
            }
            
        }

    }
}
