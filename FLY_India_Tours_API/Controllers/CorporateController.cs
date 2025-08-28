using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.BillToCompanySerice;
using Service.CorporateService;

namespace FLY_India_Tours_API.Controllers
{
    
    public class CorporateController : BaseController
    {
        private readonly ICorporateService _corporateService;
        private readonly ICurrentUserService _currentUserService;
        public CorporateController(ICorporateService corporateService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _corporateService = corporateService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCorporate()
        {
            var response = await _corporateService.Get();
            return Ok(response);
        }
    }
}

