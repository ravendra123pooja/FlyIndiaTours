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

namespace Service.CorporateService
{
    public class CorporateService : BaseService, ICorporateService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public CorporateService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<CorporateDto>>> Get()
        {
            APIResponse<List<CorporateDto>> response = new APIResponse<List<CorporateDto>>();
            try
            {


                var corporateList = await (
       from cp in _flyIndiaDbContext.TblCorporates
       join c in _flyIndiaDbContext.Countries
      on cp.CountryId equals c.Id
       where c.Status == true
       select new CorporateDto
       {
                     Id = cp.Id,
                     OfficeName = cp.OfficeName,
                     Address = cp.Address,
                     //cityName = cp.cityName,
                     CountryName = c.CountryName




                 }).ToListAsync();



                response.Message = " Corporate list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = corporateList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Corporate list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
