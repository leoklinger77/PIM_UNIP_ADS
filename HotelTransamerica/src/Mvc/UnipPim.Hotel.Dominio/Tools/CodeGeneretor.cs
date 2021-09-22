using System;
using System.Security.Cryptography;
using System.Text;

namespace UnipPim.Hotel.Dominio.Tools
{
    public static class CodeGeneretor
    {
        internal static readonly char[] chars =
            "abcPQS789!@#".ToCharArray();

        public static string GerarSenha(int tamanho)
        {
            byte[] data = new byte[4 * tamanho];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(tamanho);
            for (int i = 0; i < tamanho; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }        
    }
}
