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

namespace Service.InvoiceAgentService
{
    public class InvoiceAgentService : BaseService, IInvoiceAgentService
    {
        private readonly FlyIndiaDbContext _flyIndiaDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public InvoiceAgentService(FlyIndiaDbContext flyIndiaDbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration
            , ICurrentUserService currentUserService
            , IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _flyIndiaDbContext = flyIndiaDbContext;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }
        public async Task<APIResponse<List<InvoiceAgentDto>>> Get()
        {
            APIResponse<List<InvoiceAgentDto>> response = new APIResponse<List<InvoiceAgentDto>>();
            try
            {


                var invoiceAgentList = await (
                    from an in _flyIndiaDbContext.TblInvoiceAgents
                    join c in _flyIndiaDbContext.Countries
                    on an.CountryId equals c.Id
                    where an.Status == true
                    select new InvoiceAgentDto
                    {

                        Id = an.Id,
                        AgentName = an.AgentName,
                        address = an.Address,
                        CountryName = c.CountryName,

                    }).ToListAsync();



                response.Message = "  Invoice Agent list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = invoiceAgentList;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = " Invoice Agent list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
        public async Task<APIResponse<InvoiceAgentDto>> GetById(int Id)
        {
            APIResponse<InvoiceAgentDto> response = new APIResponse<InvoiceAgentDto>();
            try
            {


                var invoiceAgentData = await (
                    from an in _flyIndiaDbContext.TblInvoiceAgents
                    join c in _flyIndiaDbContext.Countries
                    on an.CountryId equals c.Id
                    where an.Status == true && c.Id == Id
                    select new InvoiceAgentDto
                    {

                        Id = an.Id,
                        AgentName = an.AgentName,
                        address = an.Address,
                        CountryName = c.CountryName,

                    }).FirstOrDefaultAsync();



                response.Message = "  Invoice Agent list fetched successfully";
                response.StatusCode = HttpStatusCode.OK;
                response.Data = invoiceAgentData;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                response.Message = " Invoice Agent list fetching issue";
                response.StatusCode = HttpStatusCode.OK;

                response.Success = false;
                return response;

            }
        }
    }
}
