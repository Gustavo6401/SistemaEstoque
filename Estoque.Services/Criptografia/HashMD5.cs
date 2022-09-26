using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Services.Criptografia
{
    public class HashMD5
    {
        public string Criptografar(string senha)
        {
            MD5 md5 = MD5.Create();

            byte[] textoBytes = Encoding.UTF8.GetBytes(senha);
            byte[] criptografiaBytes = md5.ComputeHash(textoBytes);

            return Convert.ToBase64String(criptografiaBytes);
        }
    }
}
