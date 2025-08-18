using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
