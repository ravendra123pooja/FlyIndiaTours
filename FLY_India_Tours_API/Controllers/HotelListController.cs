using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.BillToCompanySerice;
using Service.HotelListService;

namespace FLY_India_Tours_API.Controllers
{
   
    public class HotelListController : BaseController
    {
        private readonly IHotelListService _hotelListService;
        private readonly ICurrentUserService _currentUserService;
        public HotelListController(IHotelListService hotelListService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _hotelListService = hotelListService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetHotelList()
        {
            var response = await _hotelListService.Get();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelById(int Id)
        {
            var response = await _hotelListService.GetById(Id);
            return Ok(response);
        }
    }
}
