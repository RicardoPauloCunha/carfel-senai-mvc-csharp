using System.Collections.Generic;
using CheckPoint.Models;
using CheckPoint.Repositorios;

namespace CheckPoint.Util
{
    public class ValidacaoUtil
    {
        public bool VerificarEmailExiste(string email)
        {
            UsuarioRepositorio usuarioRep = new UsuarioRepositorio();
            List<UsuarioModel> usuarios = usuarioRep.Listar();

            foreach (var user in usuarios)
            {
                if (user.Email == email) return true;
            }

            return false;
        }

        public bool ValidarEmail(string email)
        {
            if (email.Contains("@") && email.Contains(".")) return true;

            return false;
        }
    
        public bool ValidarSenha(string senha)
        {
            if (senha.Length >= 5) return true;

            return false;
        }

        public bool ConfirmarSenha(string senha, string senha2)
        {
            if (senha == senha2) return true;

            return false;
        }

        public bool ValidarNome(string nome)
        {
            if (nome.Contains(" ") && nome.Length >= 8) return true;

            return false;
        }

        public bool ValidarTexto(string texto)
        {
            if (!string.IsNullOrEmpty(texto)) return true;

            return false;
        }
    }   
}