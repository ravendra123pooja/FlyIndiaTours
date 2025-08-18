using Infrastructure.EF.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Model.API;
using Service.Account;
using Service.UserMasterService;
using Utility;

namespace FLY_India_Tours_API.Controllers
{

    public class UserMasterController : BaseController
    {
        private readonly IUserMasterService _userMasterService;
        private readonly ICurrentUserService _currentUserService;
        public UserMasterController(IUserMasterService userMasterService, ICurrentUserService currentUserService):base(currentUserService)
        {
                _userMasterService = userMasterService;
            _currentUserService = currentUserService;
          
        }
       

        [HttpGet]
        public async Task<IActionResult> GetUserMaster()
        {
            var response = await _userMasterService.Get();
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserMasterByUserCode(string UserCode)
        {
            var response = await _userMasterService.GetByUserCode(UserCode);
            return Ok(response);
        }

    }
}
