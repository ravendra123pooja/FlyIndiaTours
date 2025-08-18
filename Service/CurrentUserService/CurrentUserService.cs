using Microsoft.AspNetCore.Http;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Account
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor  httpContextAccessor)
        {
            SessionId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimConstants.SessionId);
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            RoleId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimConstants.RoleId);
            Role = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
            Name = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimConstants.Name);
           
        }
        public string SessionId { get; set; }   
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
            
            

    }
}
