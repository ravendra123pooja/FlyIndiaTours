using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Account
{
    public interface ICurrentUserService
    {
        string SessionId { get; set; }
        string UserName { get; set; }
        string RoleId { get; set; }
        string Role { get; set; }
        string Name { get; set; }

    }
}
