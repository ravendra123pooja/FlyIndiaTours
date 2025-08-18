using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dto
{
    public class UserDto
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public DateTime TokenExpires { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }
        public string UserName { get; set; }
    }
}
