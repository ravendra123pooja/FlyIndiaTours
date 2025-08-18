using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;

namespace FLY_India_Tours_API.Controllers
{
  
    public class CompanyController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;
        public CompanyController(ICurrentUserService currentUserService) : base(currentUserService)
        {

            _currentUserService = currentUserService;

        }
    }

}

