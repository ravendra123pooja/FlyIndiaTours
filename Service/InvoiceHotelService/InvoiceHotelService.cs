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

namespace Service.InvoiceHotelService
{
    public class InvoiceHotelService : BaseService, IInvoiceHotelService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public InvoiceHotelService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<InvoiceHotelDto>>> Get()
        {
            APIResponse<List<InvoiceHotelDto>> response = new APIResponse<List<InvoiceHotelDto>>();
            try
            {


                var invoiceHotelList = await (
                   from i in _flyIndiaDbContext.TblInvoiceHotels
                   join c in _flyIndiaDbContext.Countries
                   on i.CountryId equals c.Id
                  
                   where i.Status == true
                   select new InvoiceHotelDto
                   {
                       Id = i.Id,
                       HotelName = i.HotelName,
                       address = i.Address,
                       CountryName = c.CountryName,
                       
                   }).ToListAsync();



                response.Message = " Invoice Hotel list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = invoiceHotelList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Invoice Hotel list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
