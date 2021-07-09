using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Interfaces;
using CheckPoint.Models;
using CheckPoint.Repositorios;
using CheckPoint.Util;

namespace CheckPoint.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRepositorio;
        private readonly ValidacaoUtil _validacaoUtil;

        public UsuarioController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            _validacaoUtil = new ValidacaoUtil();
        }

        public bool VerificarNome(string nome)
        {
            bool nomeValido = _validacaoUtil.ValidarNome(nome);

            if (!nomeValido)
            {
                TempData["MensengeValN"] = "Insira o seu nome completo (Mínimo 8 caracteres)";
                return false;
            }

            return true;
        }

        public bool VerificarEmail(string email)
        {
            bool emailValido = _validacaoUtil.ValidarEmail(email);

            if (!emailValido)
            {
                TempData["MensengeValE"] = "Email deve conter @ e .";
                return false;
            }
            return true;
        }

        public bool VerificarEmailExiste(string email)
        {
            bool emailExiste = _validacaoUtil.VerificarEmailExiste(email);

            if (emailExiste)
            {
                TempData["MensengeValE"] = "Email já cadastrado";
                return false;
            }

            return true;
        }

        public bool VerificarSenha(string senha)
        {
            bool senhaValida = _validacaoUtil.ValidarSenha(senha);

            if (!senhaValida)
            {
                TempData["MensengeValS"] = "Senha deve conter pelo menos 5 caracteres";
                return false;
            }

            return true;
        }

        public bool VerificarConfirmarSenha(string senha, string senha2)
        {
            bool confirmarSenha = _validacaoUtil.ConfirmarSenha(senha, senha2);

            if (!confirmarSenha)
            {
                TempData["MensengeValSs"] = "Senha incorreta";
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {

            bool nomeValido = VerificarNome(dados["nome"]);
            bool emailValido = VerificarEmail(dados["email"]);
            bool emailExiste = VerificarEmailExiste(dados["email"]);
            bool senhaValida = VerificarSenha(dados["senha"]);
            bool confirmarSenha = VerificarConfirmarSenha(dados["senha"], dados["senha2"]);

            if (nomeValido && emailValido && !emailExiste && senhaValida && confirmarSenha)
            {
                HashUtil hashUtil = new HashUtil();
                string senhaHash = hashUtil.CriptografarSenha(dados["senha"]);

                UsuarioModel usuario = new UsuarioModel(dados["nome"], dados["email"], senhaHash, "Usuario");
                _usuarioRepositorio.Cadastrar(usuario);
                
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
            bool emailValido = VerificarEmail(dados["email"]);
            bool senhaValida = VerificarSenha(dados["senha"]);

            if (emailValido && senhaValida)
            {
                UsuarioModel usuario = _usuarioRepositorio.Login(dados["email"], dados["senha"]);    

                if (usuario != null)
                {
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
    }
}