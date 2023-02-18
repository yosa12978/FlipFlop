using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FlipFlop.Helpers
{
    public interface IPasswordHelper
    {
        string ComputeHash(string password);
        bool ValidateHash(string passwordHash, string passwordPlain); // todo add better names to variables
    }
    public static class CryptoHelper // todo make class non static and implement IPasswordHelper interface
    {
        public static string NewSalt(int length)
        {
            byte[] salt = new byte[length];
            Random rand = new Random();
            rand.NextBytes(salt);
            return Convert.ToHexString(salt);
        }
        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }

}
