using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Account
{
    public interface ISecurityService
    {
        string GenerateSalt(int size);
        string GenarateSha256Hash(string input,string salt);
        string GeneratePassword();
        int GenerateOTP();

    }
}
