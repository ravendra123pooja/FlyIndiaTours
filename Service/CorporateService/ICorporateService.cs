using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CorporateService
{
    public interface ICorporateService
    {
        Task<APIResponse<List<CorporateDto>>> Get();
    }
}
