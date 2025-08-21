using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class CancellationDto
    {
        public int Id { get; set; }
        public int PerHundred { get; set; }
        public int PerFifty { get; set; }
        public int PerTwentyfive { get; set; }
    }
}
