using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.BillToCompanySerice
{
    public class BillToCompanyService : BaseService, IBillToCompanyService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public BillToCompanyService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<BillToCompanyDto>>> Get()
        {
            APIResponse<List<BillToCompanyDto>> response = new APIResponse<List<BillToCompanyDto>>();
            try
            {


                var Billtocompany = await _flyIndiaDbContext.TblBillToCompanies
                    .Where(c => c.Status == true)
                 .Select(c => new BillToCompanyDto
                 {
                     Id = c.Id,

                    CompanyName = c.CompanyName,
                     Address = c.Address,
                     Email = c.Email,
                     MobileNo = c.MobileNo


                 }).ToListAsync();



                response.Message = " Billtocompany list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = Billtocompany;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Billtocompany list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
