using Dto;
using Infrastructure.EF;
using Infrastructure.EF.Entity;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using Service.JWTAuthenticationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility;

namespace Service.UserMasterService
{
    public class UserMasterService : BaseService, IUserMasterService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public UserMasterService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<UserMasterDto>>> Get()
        {
            APIResponse<List<UserMasterDto>> response = new APIResponse<List<UserMasterDto>>();
            try
            {

                var userMasterList = await (
                from u in _flyIndiaDbContext.Usermasters

                join c in _flyIndiaDbContext.Countries
                on u.CountryId equals c.Id
                join d in _flyIndiaDbContext.TblRoleMasters
                on u.RoleId equals d.Id  
                where u.Status == true
                select new UserMasterDto
                {
                    SrNo = Convert.ToInt16(u.Srno),
                    UserCode = u.UserCode,
                    Designation = d.RoleName,
                    Name = u.Name,
                    FatherName = u.FatherName,
                    Address = u.Address,
                    State = u.State,
                    Country = c.CountryName,
                    UserName=u.UserName,
                    City=u.City
                }
                ).ToListAsync();

                response.Message = "User Master list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = userMasterList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "User Master list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }
        public async Task<APIResponse<UserMasterDto>> GetByUserCode(string UserCode)
        {
            APIResponse<UserMasterDto> response = new APIResponse<UserMasterDto>();
            try
            {

                var userdata= await (
                from u in _flyIndiaDbContext.Usermasters

                join c in _flyIndiaDbContext.Countries
                on u.CountryId equals c.Id
                join d in _flyIndiaDbContext.TblRoleMasters
                on u.RoleId equals d.Id
                where u.Status == true && u.UserCode.ToLower()== UserCode.ToLower()
                select new UserMasterDto
                {
                    SrNo = Convert.ToInt16(u.Srno),
                    UserCode = u.UserCode,
                    Designation = d.RoleName,
                    Name = u.Name,
                    FatherName = u.FatherName,
                    Address = u.Address,
                    State = u.State,
                    Country = c.CountryName,
                    UserName = u.UserName,
                    City = u.City
                }
                ).FirstOrDefaultAsync();

                response.Message = "User Master list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = userdata;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "User Master list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }

    }
}
