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

namespace Service.HotelListService
{
    public class HotelListService : BaseService, IHotelListService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public HotelListService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<HotelListDto>>> Get()
        {
            APIResponse<List<HotelListDto>> response = new APIResponse<List<HotelListDto>>();
            try
            {


                var hotelList = await _flyIndiaDbContext.HotelCreations
                    .Where(c => c.Status == true)
                 .Select(c => new HotelListDto
                 {
                     Id = c.Id,

                     HotelName = c.HotelName,
                     HotelLocation = c.HotelLocation,
                     CityName = c.CityName,
                     HotelCategory = c.HotelCategory


                 }).ToListAsync();



                response.Message = "Hotel list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = hotelList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Hotel list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;
            }
        }
        public async Task<APIResponse<HotelListDto>> GetById(int Id)
        {
            APIResponse<HotelListDto> response = new APIResponse<HotelListDto>();
            try
            {


                var hotelData = await _flyIndiaDbContext.HotelCreations
                    .Where(c => c.Status == true && c.Id == Id)
                 .Select(c => new HotelListDto
                 {
                     Id = c.Id,

                     HotelName = c.HotelName,
                     HotelLocation = c.HotelLocation,
                     CityName = c.CityName,
                     HotelCategory = c.HotelCategory


                 }).FirstOrDefaultAsync();



                response.Message = "Hotel list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = hotelData;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Hotel list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;
            }
        }
    }
}
