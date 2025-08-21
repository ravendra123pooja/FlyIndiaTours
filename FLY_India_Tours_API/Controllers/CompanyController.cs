using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.CompanyService;

namespace FLY_India_Tours_API.Controllers
{
  
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly ICurrentUserService _currentUserService;
        public CompanyController(ICompanyService companyService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _companyService = companyService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            var response = await _companyService.Get();
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyByID(int Id)
        {
            var response = await _companyService.GetById(Id);
            return Ok(response);
        }
    }

}

