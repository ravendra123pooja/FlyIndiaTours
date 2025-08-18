using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoleService
{
    public interface IRoleService
    {
        Task<APIResponse<List<RoleDto>>> Get();
    }
}
