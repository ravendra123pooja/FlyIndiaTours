using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.BillToCompanySerice;
using Service.CityAttractionService;

namespace FLY_India_Tours_API.Controllers
{
   
    public class CityAttractionController : BaseController
    {
        private readonly ICityAttractionService _cityAttractionService;
        private readonly ICurrentUserService _currentUserService;
        public CityAttractionController(ICityAttractionService cityAttractionService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _cityAttractionService = cityAttractionService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCityAttraction()
        {
            var response = await _cityAttractionService.Get();
            return Ok(response);
        }
    }
}
