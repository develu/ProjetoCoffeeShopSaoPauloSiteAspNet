using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoCoffeeShoopSaoPaulo.Utils
{
    public static class CriptografarSenha
    {
        public static string codificarSenha(string senhaOriginal)
        {
            MD5 md5;
            byte[] senha;
            byte[] codsenha;


            md5 = new MD5CryptoServiceProvider();
            senha = ASCIIEncoding.Default.GetBytes(senhaOriginal);
            codsenha = md5.ComputeHash(senha);


            return Convert.ToBase64String(codsenha);

        }
    }

}
