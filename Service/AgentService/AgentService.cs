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

namespace Service.AgentService
{
    public class AgentService : BaseService, IAgentService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public AgentService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<AgentDto>>> Get()
        {
            APIResponse<List<AgentDto>> response = new APIResponse<List<AgentDto>>();
            try
            {


                var agentList = await( 
                    from a in _flyIndiaDbContext.BookingAgents
                    join c in _flyIndiaDbContext.Countries
                    on a.CountryId equals c.Id
                    where a.Status == true
                    select new AgentDto
                    {
                        SrNo = Convert.ToInt16(a.Srno),
                        agentCode = a.AgentCode,
                        bookingAgentName = a.BookingAgentName,
                        businessName = a.BusinessName,
                        natureOfBusinesss = a.NatureOfBusinesss,
                        city = a.City,
                        CountryName = c.CountryName,
                     
                    }).ToListAsync();



                response.Message = " Agent list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = agentList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = "Agent list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
