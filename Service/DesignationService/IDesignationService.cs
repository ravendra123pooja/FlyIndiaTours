using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DesignationService
{
    public interface IDesignationService
    {
        Task<APIResponse<List<DesignationDto>>> Get();
        Task<APIResponse<DesignationDto>> GetById(int Id);
    }
}
