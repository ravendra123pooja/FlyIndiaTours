using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserMasterService
{
    public interface IUserMasterService
    {
        Task<APIResponse<List<UserMasterDto>>> Get();
        Task<APIResponse<UserMasterDto>> GetByUserCode(string UserCode);
    }
}
