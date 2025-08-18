using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dto
{
    public class UserMasterDto
    {
       
      
        public int    SrNo { get; set; }
        public string PhotoPath { get; set; }
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }

    }
}