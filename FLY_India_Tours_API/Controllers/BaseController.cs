using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;


namespace FLY_India_Tours_API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        public BaseController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }

        public string UserName
        {
            get
            {
                return _currentUserService.UserName;
            }
        }
        public string RoleId
        {
            get
            {
                return _currentUserService.RoleId;
            }
        }
        public string Role
        { 
            get
            {
            return _currentUserService.Role;
            }
        }
        public string Name
        {
            get
            {
                return _currentUserService.Name;
            }
        }

    }
}
