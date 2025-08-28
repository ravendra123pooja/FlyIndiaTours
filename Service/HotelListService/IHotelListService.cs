using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HotelListService
{
    public interface IHotelListService
    {
        Task<APIResponse<List<HotelListDto>>> Get();
        Task<APIResponse<HotelListDto>> GetById(int Id);
    }
}
