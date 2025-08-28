using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dto
{
    public class ToursDisplayDto
    {
        public string SerialCode { get; set; }
        public string TourCategory { get; set; }
        public string TourType { get; set; }
        public string TourTitle { get; set; }
        public string TourPackageName { get; set; }
        public string TourDestination { get; set; }
        public string Images { get; set; }
    }
}
