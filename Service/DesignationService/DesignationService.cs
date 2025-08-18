using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using Service.UserMasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.DesignationService
{
    public class DesignationService : BaseService, IDesignationService  
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public DesignationService(FlyIndiaDbContext flyIndiaDbContext,  IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<DesignationDto>>> Get()
        {
            APIResponse<List<DesignationDto>> response = new APIResponse<List<DesignationDto>>();
            try
            {


                var designationList = await _flyIndiaDbContext.TblRoleMasters
                 .Where(c => c.Status == true)
                 .Select(c => new DesignationDto
                 {
                     Id = c.Id,
                     RoleName = c.RoleName,
                    
                 }).ToListAsync();

               

                response.Message = " Designation list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = designationList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Designation list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }
        public async Task<APIResponse<DesignationDto>> GetById(int Id)
            {
            APIResponse<DesignationDto> response = new APIResponse<DesignationDto>();
            try
            {


                var designationData = await _flyIndiaDbContext.TblRoleMasters
                 .Where(c => c.Status == true && c.Id==Id)
                 .Select(c => new DesignationDto
                 {
                     Id = c.Id,
                     RoleName = c.RoleName,

                 }).FirstOrDefaultAsync();



                response.Message = " Designation list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = designationData;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Designation list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }


    }
}
