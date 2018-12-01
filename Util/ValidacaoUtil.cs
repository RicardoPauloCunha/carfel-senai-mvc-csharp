using Projeto_CarFel_CheckPoint_Web.Models;

namespace Projeto_CarFel_CheckPoint_Web.Util
{
    public class ValidacaoUtil
    {
        public bool ValEmail(string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }
            return false;
        }
    
        public bool ValSenha(string senha)
        {
            if (senha.Length >= 6)
            {
                return true;
            }
            return false;
        }

        public bool ValSenha2(string senha, string senha2)
        {
            if (senha == senha2)
            {
                return true;
            }
            return false;
        }

        public bool ValNome(string nome)
        {
            if (nome.Contains(" ") && nome.Length >= 8)
            {
                return true;
            }
            return false;
        }
    }   
}