using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.DesignationService;
using Service.UserMasterService;

namespace FLY_India_Tours_API.Controllers
{

    public class DesignationController : BaseController
    {
        private readonly IDesignationService _designationService;
        private readonly ICurrentUserService _currentUserService;
        public DesignationController(IDesignationService designationService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _designationService = designationService;
            _currentUserService = currentUserService;
          
       }
        [HttpGet]
        public async Task<IActionResult> GetDesignation()
        {
            var response = await _designationService.Get();
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetDesignationByID(int Id)
        {
            var response = await _designationService.GetById(Id);
            return Ok(response);
        }
    }
   


}
