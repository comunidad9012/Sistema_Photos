using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DomainClass.Common
{
    public static class CryptographyMethod
    {
        public static string Encrypt(this string value)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = sHA256.ComputeHash(encoding.GetBytes(value));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                sb.AppendFormat("{0:x2}", bytes[i]);
            return sb.ToString();
        }
    }
}
