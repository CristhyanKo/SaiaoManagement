using System.Security.Cryptography;
using System.Text;

namespace Saiao.Common.Security
{
    public static class Encrypt
    {
        public static string Encrypta(this string valor)
        {
            valor += "-%%!o<Asd|!@_ekLMSpcwUq.PIas88dgiL3PE)R.pNdt]_!$!";
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(valor));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
