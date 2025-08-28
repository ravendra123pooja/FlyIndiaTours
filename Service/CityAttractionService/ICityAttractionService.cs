using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CityAttractionService
{
    public interface ICityAttractionService
    {
        Task<APIResponse<List<CityAttractionDto>>> Get();
    }
}
