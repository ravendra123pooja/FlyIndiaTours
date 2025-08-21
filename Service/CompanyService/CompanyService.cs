using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using Service.DesignationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.CompanyService
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public CompanyService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<CompanyDto>>> Get()
        {
            APIResponse<List<CompanyDto>> response = new APIResponse<List<CompanyDto>>();
            try
            {


                var companyList = await (
                     from cm in _flyIndiaDbContext.TblCompanies
                     join c in _flyIndiaDbContext.Countries
                    on cm.CountryId equals c.Id
                     where c.Status == true
                     select new CompanyDto
                     {

                         ID = cm.Id,
                         PhotoPath = cm.PhotoPath,
                         CompanyName = cm.CompanyName,
                         Address = cm.Address,
                         Pincode = cm.Pincode,
                         State = cm.State,
                         City = cm.City,
                         Country = c.CountryName,
                         MobileNo = cm.MobileNo,
                         Email = cm.Email

                     }
                     ).ToListAsync();

                response.Message = " Company list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = companyList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Company list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }



        public async Task<APIResponse<CompanyDto>> GetById(int Id)
        {
            APIResponse<CompanyDto> response = new APIResponse<CompanyDto>();
            try
            {


                var companydata = await (
                     from cm in _flyIndiaDbContext.TblCompanies
                     join c in _flyIndiaDbContext.Countries
                    on cm.CountryId equals c.Id
                     where c.Status == true
                     select new CompanyDto
                     {

                         ID = cm.Id,
                         PhotoPath = cm.PhotoPath,
                         CompanyName = cm.CompanyName,
                         Address = cm.Address,
                         Pincode = cm.Pincode,
                         State = cm.State,
                         City = cm.City,
                         Country = c.CountryName,
                         MobileNo = cm.MobileNo,
                         Email = cm.Email

                     }
                     ).FirstOrDefaultAsync(); 

                response.Message = " Company list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = companydata;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Company list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }

    
    }
}
