using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CountryService
{
    public interface ICountryService
    {
        Task<APIResponse<List<CountryDto>>> Get();
    }
}
