using Microsoft.AspNetCore.Mvc;
using Model.API;
using Service.Account;
using Service.CountryService;
using Service.RoleService;
using System.Text.Json;
using Utility;
namespace FLY_India_Tours_API.Controllers.CountryList
{
    public class CommonController : BaseController
    {
        private readonly ICountryService _country;
        private readonly IRoleService _roleService;
        public CommonController(ICountryService country,
            IRoleService roleService,
            ICurrentUserService currentUserService) : base(currentUserService)
        {
            _country = country;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountry()
        {
            var response = await _country.Get();
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult>GetRole()
        {
            var response = await _roleService.Get();
            return Ok(response);
        }
    }
}
