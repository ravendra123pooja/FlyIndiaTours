using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.AgentService;
using Service.CurrencyService;

namespace FLY_India_Tours_API.Controllers
{
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICurrentUserService _currentUserService;
        public CurrencyController(ICurrencyService currencyService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _currencyService = currencyService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCurrency()
        {
            var response = await _currencyService.Get();
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyByID(int Id)
        {
            var response = await _currencyService.GetById(Id);
            return Ok(response);
        }
    }
}
