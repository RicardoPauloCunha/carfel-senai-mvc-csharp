using System.Collections.Generic;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;

namespace Projeto_CarFel_CheckPoint_Web.Util
{
    public class ValidacaoUtil
    {
        public bool ValEmailExist(string email)
        {
            UsuarioRepositorio usuarioRep = new UsuarioRepositorio();
            List<UsuarioModel> usuarios = usuarioRep.Listar();

            foreach (var user in usuarios)
            {
                if (user.Email == email) return false;
            }

            return true;
        }
        public bool ValEmail(string email)
        {
            if (email.Contains("@") && email.Contains(".")) return true;

            return false;
        }
    
        public bool ValSenha(string senha)
        {
            if (senha.Length >= 5) return true;

            return false;
        }

        public bool ValSenha2(string senha, string senha2)
        {
            if (senha == senha2) return true;

            return false;
        }

        public bool ValNome(string nome)
        {
            if (nome.Contains(" ") && nome.Length >= 8) return true;

            return false;
        }

        public bool valTexto(string texto)
        {
            if (!string.IsNullOrEmpty(texto)) return true;

            return false;
        }
    }   
}