using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Longitude { get; set; }
        public string MacAddress { get; set; }
        public string Latitude { get; set; }
        public string Platform { get; set; }
        public string CaptchaCode { get; set; }
        public string otp { get; set; }
        public bool isotpSent { get; set; }
    }
}


