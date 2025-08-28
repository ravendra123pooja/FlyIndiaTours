using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.InvoiceAgentService;
using Service.InvoiceHotelService;

namespace FLY_India_Tours_API.Controllers
{
   
    public class InvoiceAgentController : BaseController
    {
        private readonly IInvoiceAgentService _invoiceAgentService;
        private readonly ICurrentUserService _currentUserService;
        public InvoiceAgentController(IInvoiceAgentService invoiceAgentService, ICurrentUserService currentUserService) : base(currentUserService)
        {
           _invoiceAgentService = invoiceAgentService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetInvoiceAgent()
        {
            var response = await _invoiceAgentService.Get();
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAgentById( int Id )
        {
            var response = await _invoiceAgentService.GetById( Id );
            return Ok(response);
        }
    }
}
