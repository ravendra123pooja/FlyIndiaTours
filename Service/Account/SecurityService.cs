using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Service.Account
{
    public class SecurityService : ISecurityService
    {
        public string GenerateSalt(int size)
        {
            using RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rNGCryptoServiceProvider.GetBytes(buff);
            return Convert.ToBase64String(buff);

        }
        public string GenarateSha256Hash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            using SHA256Managed sHA256Managed=new SHA256Managed();
            byte[] hash = sHA256Managed.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public string GeneratePassword()
        {
            string UperCase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string LowerCase = "qwertyuiopasdfghjklzxcvbnm";
            string Digit = "1234567890";
            string allCharacters=UperCase + LowerCase + Digit;
            Random random = new Random();
            string password = "";
            for (int i = 0; i < 9; i++)
            {
                double  rand=random.NextDouble();
                if (i > 0)
                    password += UperCase.ToCharArray()[(int)Math.Floor(rand * UperCase.Length)];
                else password += allCharacters.ToCharArray()[(int)Math.Floor(rand * allCharacters.Length)];

            }
            return password;

        }
        public int GenerateOTP()
        {
            int _min = 1000;
            int _max = 9999;
            Random random = new Random();
            return  random.Next(_min,_max);
        }

    }
}
