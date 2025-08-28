using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.BillToCompanySerice;
using Service.InvoiceAgentService;

namespace FLY_India_Tours_API.Controllers
{
   
    public class BillToCompanyController : BaseController
    {
        private readonly IBillToCompanyService _billToCompanyService;
        private readonly ICurrentUserService _currentUserService;
        public BillToCompanyController(IBillToCompanyService billToCompanyService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _billToCompanyService = billToCompanyService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetBillToCompany()
        {
            var response = await _billToCompanyService.Get();
            return Ok(response);
        }
    }
}
