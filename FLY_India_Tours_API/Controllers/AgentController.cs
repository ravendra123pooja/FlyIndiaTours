using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Account;
using Service.AgentService;

namespace FLY_India_Tours_API.Controllers
{
    
    public class AgentController : BaseController
    {
        private readonly IAgentService _agentService;
        private readonly ICurrentUserService _currentUserService;
        public AgentController(IAgentService agentService, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _agentService = agentService;
            _currentUserService = currentUserService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAgent()
        {
            var response = await _agentService.Get();
            return Ok(response);
        }
    }
}
