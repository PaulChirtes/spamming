using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PArtTimeJobs.BLL.Cryptography
{
    public static class Crypto
    {
        public static string Encrypt(string input)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var bytes = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input)).ToList();

            var builder = new StringBuilder();
            bytes.ForEach(b => builder.Append(b.ToString("x2")));            
            return builder.ToString();
        }
    }
}
