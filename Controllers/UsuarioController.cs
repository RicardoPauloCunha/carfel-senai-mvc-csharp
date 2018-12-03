using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Interfaces;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CheckPoint_Web.Util;

namespace Projeto_CarFel_CheckPoint_Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuario UsuarioRepositorio{ get; set;}

        public UsuarioController()
        {
            //Polimorfismo
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpGet]
        public IActionResult Cadastrar() 
        {
            return View();
        }

        //Validação do Nome
        public bool ValidarNome(string nome)
        {
            ValidacaoUtil val = new ValidacaoUtil();
            bool valN = val.ValNome(nome);
            if (!valN)
            {
                TempData["MensengeValN"] = "Insira o nome completo";
                return true;
            }
            return false;
        }

        //Validação do Email
        public bool ValidarEmail(string email)
        {
            ValidacaoUtil val = new ValidacaoUtil();
            bool valE = val.ValEmail(email);
            if (!valE)
            {
                TempData["MensengeValE"] = "Email deve conter @ e .";
                return true;
            }
            return false;
        }

        //Validação da Senha
        public bool ValidarSenha(string senha)
        {
            ValidacaoUtil val = new ValidacaoUtil();
            bool valS = val.ValSenha(senha);
            if (!valS)
            {
                TempData["MensengeValS"] = "Senha deve conter pelo menos 6 caracteres";
                return true;
            }
            return false;
        }

        //Validação da Senha 2
        public bool ValidarSenha2(string senha, string senha2)
        {
            ValidacaoUtil val = new ValidacaoUtil();
            bool valSs = val.ValSenha2(senha, senha2);
            if (!valSs)
            {
                TempData["MensengeValSs"] = "Senha incorreta";
                return true;
            }
            return false;
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {
            UsuarioModel usuario = new UsuarioModel();

            //Validação do nome, email e senha;
            ValidacaoUtil val = new ValidacaoUtil();
            bool valN = ValidarNome(dados["nome"]);
            bool valE = ValidarEmail(dados["email"]);
            bool valS = ValidarSenha(dados["senha"]);
            bool valSs = ValidarSenha2(dados["senha"], dados["senha2"]);

            //Caso esteja certo cadastra usuario
            if (valN && valE && valSs)
            {
                usuario.Nome = dados["nome"];
                usuario.Email = dados["email"];
                usuario.Senha = dados["senha"];
                usuario.Tipo = "usuario";

                UsuarioRepositorio.Cadastrar(usuario);
                
                //Retorma mensagem para usuario que login foi efetuado com sucesso
                TempData["valCadastrar"] = "Usuario cadastrado com sucesso";
            }
            else
            {
                //Caso contrario retorna mensagem de falha
                TempData["IvalCadastrar"] = "Falha ao cadastrar. Dados inválidos";
            }
            
            return View();
        }
    
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection dados)
        {
            ValidacaoUtil val = new ValidacaoUtil();
            
            //Validação do email e senha
            bool valE = ValidarEmail(dados["email"]);
            bool valS = ValidarSenha(dados["senha"]);

            //Caso esteja tudo certo efetua o processo de login
            if (valE && valS)
            {
                string email = dados["email"];
                string senha = dados["senha"];
                //Validação do login
                UsuarioModel usuario = UsuarioRepositorio.Login(email, senha);    

                //Verifica se o usuario foi encontrado       
                if (usuario != null)
                {
                    //Caso encontrado adiciona ele a uma session
                    HttpContext.Session.SetString("UsuarioLogId", usuario.Id.ToString());
                    //Retorna para a pagina home
                    return RedirectToAction("Home", "Pagina");
                }
                else
                {
                    //Caso não encontrado retorna mensagem de erro
                    TempData["MensValLogin"] = "Email ou Senha Incorretos";
                }
            }
            else
            {
                //Caso dados estejam incorretos
                TempData["MensValLogin"] = "Falha ao Logar. Dados Inválidos";
            }
            
            return View();
        }
    }
}