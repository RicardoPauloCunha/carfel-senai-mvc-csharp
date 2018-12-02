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
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpGet]
        public IActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {
            UsuarioModel usuario = new UsuarioModel();
            //Validação do nome, email e senha;
            ValidacaoUtil val = new ValidacaoUtil();
            bool valN = val.ValNome(dados["nome"]);
            bool valE = val.ValEmail(dados["email"]);
            bool valS = val.ValSenha(dados["senha"]);
            bool valSs = val.ValSenha2(dados["senha"], dados["senha2"]);

            //retorna uma mensagem caso algo esta errado
            if (!valN)
            {
                TempData["MensengeValN"] = "Insira o nome completo";
            }
            if (!valE)
            {
                TempData["MensengeValE"] = "Email deve conter @ e .";
            }
            if (!valS)
            {
                TempData["MensengeValS"] = "Senha deve conter pelo menos 6 caracteres";
            }
            if (!valSs)
            {
                TempData["MensengeValSs"] = "Senha incorreta";
            }

            //caso esteja certo cadastra usuario
            if (valN && valE && valSs)
            {
                usuario.Nome = dados["nome"];
                usuario.Email = dados["email"];
                usuario.Senha = dados["senha"];
                usuario.Tipo = dados["tipo"];

                UsuarioRepositorio.Cadastrar(usuario);
                
                //retorma mensagem para usuario que login foi efetuado com sucesso
                TempData["valCadastrar"] = "Usuario cadastrado com sucesso";
            }
            else
            {
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
            bool valE = val.ValEmail(dados["email"]);
            bool valS = val.ValSenha(dados["senha"]);

            if (!valE)
            {
                TempData["MensengeValE"] = "Email deve conter @ e .";
            }
            if (!valS)
            {
                TempData["MensengeValS"] = "Senha deve conter pelo menos 6 caracteres";
            }

            if (valE && valS)
            {
                string email = dados["email"];
                string senha = dados["senha"];
                UsuarioModel usuario = UsuarioRepositorio.Login(email, senha);           
                if (usuario != null)
                {
                    // HttpContext.Session.SetString("idUsuario", usuario.Id.ToString());
                    HttpContext.Session.SetString("UsuarioLogId", usuario.Id.ToString());
                    return RedirectToAction("Home", "Pagina");
                }
                else
                {
                    TempData["MensValLogin"] = "Email ou Senha Incorretos";
                }
            }
            else
            {
                TempData["MensValLogin"] = "Falha ao Logar. Dados Inválidos";
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Home(){
            return View();
        }
    }
}