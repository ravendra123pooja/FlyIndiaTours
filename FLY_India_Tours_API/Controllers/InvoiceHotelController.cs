using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.CurrencyService;
using Service.InvoiceHotelService;

namespace FLY_India_Tours_API.Controllers
{
  
    public class InvoiceHotelController : BaseController
    {
        private readonly IInvoiceHotelService _invoiceHotelService;
        private readonly ICurrentUserService _currentUserService;
        public InvoiceHotelController(IInvoiceHotelService invoiceHotelService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _invoiceHotelService = invoiceHotelService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetInvoiceHotel()
        {
            var response = await _invoiceHotelService.Get();
            return Ok(response);
        }
    }
}
