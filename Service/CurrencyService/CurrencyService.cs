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

namespace Service.CurrencyService
{
    public class CurrencyService : BaseService, ICurrencyService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public CurrencyService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<CurrencyDto>>> Get()
        {
            APIResponse<List<CurrencyDto>> response = new APIResponse<List<CurrencyDto>>();
            try
            {


                var currencyList = await _flyIndiaDbContext.TblCurrencies

                 .Select(c => new CurrencyDto
                 {
                     Id = c.Id,
                     CurrencyCode = c.CurrencyCode

                 }).ToListAsync();

               

                response.Message = " Currency list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = currencyList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Currency list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }

        public async Task<APIResponse<CurrencyDto>> GetById(int Id)
        {
            APIResponse<CurrencyDto> response = new APIResponse<CurrencyDto>();
            try
            {


                var currencyData = await _flyIndiaDbContext.TblCurrencies
                    .Where(c => c.Id == Id)
                 .Select(c => new CurrencyDto
                 {
                     Id = c.Id,
                     CurrencyCode = c.CurrencyCode

                 }).FirstOrDefaultAsync();



                response.Message = " Currency list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = currencyData;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Currency list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
