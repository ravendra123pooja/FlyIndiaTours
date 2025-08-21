using Dto;
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.API;
using Service.Account;
using Service.CompanyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.CancellationService
{
    public class CancellationService : BaseService, ICancellationService 
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public CancellationService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<CancellationDto>>> Get()
        {
            APIResponse<List<CancellationDto>> response = new APIResponse<List<CancellationDto>>();
            try
            {


                var cancellationList = await _flyIndiaDbContext.TblRoleMasters
                 .Where(c => c.Status == true)
                 .Select(c => new CancellationDto
                 {
                     Id = c.Id,
                     PerHundred = c.PerHundred,
                     PerFifty = c.PerFifty,
                     PerTwentyfive = c.PerTwentyfive

                 }).ToListAsync();



                response.Message = " Cancellation list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = cancellationList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Cancellation list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }

        }
    }
}
