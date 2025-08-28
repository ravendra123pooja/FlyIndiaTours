using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Model.API;
using Service.Account;
using Service.ToursDisplay;
using Utility;

namespace FLY_India_Tours_API.Controllers
{
   
    public class TourDisplayController : BaseController
    {
        private readonly IToursDisplayService _toursDisplayService;
        private readonly ICurrentUserService _currentUserService;
        public TourDisplayController(IToursDisplayService toursDisplayService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _toursDisplayService = toursDisplayService;

            _currentUserService= currentUserService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTours()
        {
            var response = await _toursDisplayService.GetToursDisplayList();
            //LogInfo.WriteLog("Account_Log", $"{nameof(Login)}: Response user {loginModel.UserName}----> {JsonSerializer.Serialize(response)}");
            return Ok(response);
        }
    }
   
}
