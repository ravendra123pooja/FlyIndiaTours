using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using Service.AgentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Service.ToursDisplay
{
    public class ToursDisplayService : BaseService, IToursDisplayService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;


        public ToursDisplayService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<ToursDisplayDto>>> GetToursDisplayList()
        {
            APIResponse<List<ToursDisplayDto>> response = new APIResponse<List<ToursDisplayDto>>();
            try
            {
                var toursDisplayList = await _flyIndiaDbContext.SameDayTours.Where(a => a.Status == true ).
                    Select(a => new ToursDisplayDto
                    {
                        SerialCode=a.SerialCode,
                        TourCategory = a.TourCategory,
                        TourType = a.TourType,
                        TourTitle = a.TourTitle,
                        TourDestination = a.TourDestination,
                        Images = a.Images,
                        TourPackageName = a.TourPackageName,
                    })
                  .ToListAsync();
                response.Message = " Tours list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = toursDisplayList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Tours list fetching issue";
                response.StatusCode = HttpStatusCode.OK;
                response.Success = false;
                return response;

            }
        }
    }
}
