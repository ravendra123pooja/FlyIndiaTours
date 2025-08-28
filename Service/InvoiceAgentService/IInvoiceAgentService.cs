using Dto;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InvoiceAgentService
{
    public interface IInvoiceAgentService
    {
        Task<APIResponse<List<InvoiceAgentDto>>> Get();
        Task<APIResponse<InvoiceAgentDto>> GetById(int Id);
    }
}
