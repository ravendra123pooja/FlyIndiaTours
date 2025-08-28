using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using Service.CityAttractionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.CityAttractionService
{
    public class CityAttractionService : BaseService, ICityAttractionService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public CityAttractionService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<CityAttractionDto>>> Get()
        {
            APIResponse<List<CityAttractionDto>> response = new APIResponse<List<CityAttractionDto>>();
            try
            {


                var cityAttraction = await _flyIndiaDbContext.CityAttractions
                    .Where(c => c.Status == true)
                 .Select(c => new CityAttractionDto
                 {
                     Id = c.Id,

                     AttractionName = c.AttractionName,
                     AttractionCity = c.AttractionCity,
                     ActivityMinDurationHours = c.ActivityMinDurationHours,
                     ActivityMaxDurationHours = c.ActivityMaxDurationHours,
                     CostPerPerson = c.CostPerPerson,
                     CostIncludes = c.CostIncludes


                 }).ToListAsync();



                response.Message = " CityAttraction list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = cityAttraction;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "CityAttraction list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
