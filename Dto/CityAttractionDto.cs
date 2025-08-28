using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CityAttractionDto
    {
        public int Id { get; set; }
        public string? AttractionName { get; set; }
        public string? AttractionCity { get; set; }
        public int? ActivityMinDurationHours { get; set; }
         public int? ActivityMaxDurationHours { get; set; }
        public decimal? CostPerPerson { get; set; }
        public string? CostIncludes { get; set; }
    }
}
