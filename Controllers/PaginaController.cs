using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Interfaces;
using CheckPoint.Models;
using CheckPoint.Repositorios;
using CheckPoint.Util;

namespace Projeto_CarFel_CheckPoint.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ValidacaoUtil _validacaoUtil;
        private readonly IUsuario _usuarioRepositorio;
        private readonly IMensagem _mensagemRepositorio;

        public PaginaController()
        {
            _validacaoUtil = new ValidacaoUtil();
            _usuarioRepositorio = new UsuarioRepositorio();
            _mensagemRepositorio = new MensagemRepositorio();
        }

        [HttpGet]
        public IActionResult Home()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        [HttpGet]
        public IActionResult Empresa()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        [HttpGet]
        public IActionResult Precos()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
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

        public bool VerificarTexto(string texto)
        {
            bool textoValido = _validacaoUtil.ValidarTexto(texto);

            if (!textoValido)
            {
                TempData["MensengeValT"] = "Insira um texto para poder enviar a mensagem";
                return false;
            }

            return true;
        }

        public bool VerificarAssunto(string Assunto)
        {
            bool assuntoValido = _validacaoUtil.ValidarTexto(Assunto);

            if (!assuntoValido)
            {
                TempData["MensengeValA"] = "Insira um assunto para poder enviar a mensagem";
                return false;
            }

            return true;
        }

        [HttpGet]
        public IActionResult Contato()
        {
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));

                if (UsuarioLogId == 1)
                    return RedirectToAction("ListarMensagem", "Pagina");                    

                ViewData["UsuarioLog"] = _usuarioRepositorio.BuscarPorId(UsuarioLogId);
            }

            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        [HttpPost]
        public IActionResult Contato(IFormCollection dados)
        {  
            int UsuarioLogId = 0;

            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                ViewBag.UserLog = UsuarioLogId;
            }
            
            bool emailValido = true;

            if (HttpContext.Session.GetString("UsuarioLogId") == null)
                emailValido = VerificarEmail(dados["email"]);
            
            bool assuntoValido = VerificarAssunto(dados["assunto"]);
            bool textoValido = VerificarTexto(dados["texto"]);

            if (!emailValido || !assuntoValido || !textoValido)
            {
                TempData["FalhaCadMen"] = "Falha ao enviar a mensagem. Dados inválidos";
                return View();
            }

            MensagemModel mensagem = new MensagemModel(dados["nome"], dados["email"], dados["assunto"], dados["texto"], "Pedente");

            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(UsuarioLogId);

                mensagem.Nome = usuario.Nome;
                mensagem.Email = usuario.Email;

                ViewData["UsuarioLog"] = usuario;
            }
            
            _mensagemRepositorio.Cadastrar(mensagem);

            TempData["SucessoCadMen"] = "Mensagem enviada com sucesso";
            return View();
        }

        [HttpGet]
        public IActionResult ListarMensagem()
        {
            ViewData["Mensagens"] = _mensagemRepositorio.Listar();
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            MensagemModel mensagem = _mensagemRepositorio.BuscarPorId(id);

            if (mensagem == null)
            {
                TempData["AvaliacaoSucesso"] = "Mensagem não encontrada";
                return View();
            }
            
            _mensagemRepositorio.Excluir(mensagem);

            TempData["AvaliacaoSucesso"] = "Mensagem Excluida da Lista";
            return RedirectToAction("ListarMensagem");
        }
    }
}