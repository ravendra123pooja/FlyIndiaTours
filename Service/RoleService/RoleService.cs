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
namespace Service.RoleService
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISecurityService _securityService;
        private readonly AppSettings _appSetting;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public RoleService(
            FlyIndiaDbContext flyIndiaDbContext,
            ICurrentUserService currentUserService, IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, IRefreshTokenGenerator refreshTokenGenerator
            , IUnitOfWork unitOfWork
            ) : base(unitOfWork)
        {
            _currentUserService = currentUserService;
            _flyIndiaDbContext = flyIndiaDbContext;
        }


        public async Task<APIResponse<List<RoleDto>>> Get()
        {
            APIResponse<List<RoleDto>> response = new APIResponse<List<RoleDto>>();
            try
            {
                
                var RoleList = await _flyIndiaDbContext.TblRoleMasters
                  .Where(c => c.Status == true)
                  .Select(c => new RoleDto
                  {
                      Id = c.Id,
                      RoleName = c.RoleName,
                      Status = c.Status
                  })
                  .ToListAsync();
                response.Message = "Role list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = RoleList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Role list fetching issue";
                response.StatusCode = HttpStatusCode.OK;
                
                response.Success = false;
                return response;
                
            }
            
        }

    }
}
