using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.JWTAuthenticationManager;
using Model.API;
using Utility;
using System.Text.Json;

namespace FLY_India_Tours_API.Controllers
{
   
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes ="Bearer")]
    [ApiExplorerSettings(IgnoreApi =false)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;

        public  AccountController(IAccountService accountService ,IJWTAuthenticationManager jWTAuthenticationManager )
        {
            _accountService = accountService;
            _jwtAuthenticationManager = jWTAuthenticationManager;   
        }

        [HttpPost]
        [AllowAnonymous]
         public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var response = await _accountService.Login(loginModel);
            LogInfo.WriteLog("Account_Log", $"{nameof(Login)}: Response user {loginModel.UserName}----> {JsonSerializer.Serialize(response)}");
            return Ok(response);
        }
        
    }
}
