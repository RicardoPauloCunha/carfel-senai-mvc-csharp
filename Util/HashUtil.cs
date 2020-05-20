using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto_CarFel_CheckPoint_Web.Util
{
    public class HashUtil
    {
        private readonly HashAlgorithm _algoritimo;

        public HashUtil()
        {
            _algoritimo = SHA512.Create();
        }

        public string CriptografarSenha(string senha)
        {
            var encodeValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritimo.ComputeHash(encodeValue);

            var sb = new StringBuilder();

            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
            {
                throw new NullReferenceException("Cadastrar uma senha");
            }

            var encryptedPassword = _algoritimo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

            var sb = new StringBuilder();

            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString () == senhaCadastrada;
        }
    }
}