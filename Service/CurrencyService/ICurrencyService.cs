using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CurrencyService
{
    public interface ICurrencyService
    {
        Task<APIResponse<List<CurrencyDto>>> Get();
        Task<APIResponse<CurrencyDto>> GetById(int Id);
    }
}
