using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.CancellationService;
using Service.CompanyService;

namespace FLY_India_Tours_API.Controllers
{
  
    public class CancellationController : BaseController
    {
        private readonly ICancellationService  _cancellationService;
     private readonly ICurrentUserService _currentUserService;
        public CancellationController(ICancellationService cancellationService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _cancellationService =cancellationService ;
              _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCancellation()
        {
            var response = await _cancellationService.Get();
            return Ok(response);
        }
    }
}
