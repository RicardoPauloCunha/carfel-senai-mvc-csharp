using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CheckPoint.Controllers
{
    public class PaginaController : Controller
    {
        //Pagina Home
        [HttpGet]
        public IActionResult Home()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Empresa
        [HttpGet]
        public IActionResult Empresa()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Preçõs
        [HttpGet]
        public IActionResult Precos()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Contato
        [HttpGet]
        public IActionResult Contato()
        {
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                if (UsuarioLogId == 1)
                {
                    return RedirectToAction("ListarMensagem", "Pagina");                    
                }
                UsuarioRepositorio usuarioRep = new UsuarioRepositorio();

                ViewData["UsuarioLog"] = usuarioRep.BuscarPorUser(UsuarioLogId);
            }

            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        [HttpPost]
        public IActionResult Contato(IFormCollection dados)
        {  
            MensagemModel mensagem = new MensagemModel();
            mensagem.Nome = dados["nome"];
            mensagem.Email = dados["email"];
            mensagem.Assunto = dados["assunto"];
            mensagem.Texto = dados["texto"];

            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                UsuarioRepositorio usuarioRep = new UsuarioRepositorio();

                UsuarioModel usuario = usuarioRep.BuscarPorUser(UsuarioLogId);
                mensagem.Nome = usuario.Nome;
                mensagem.Email = usuario.Email;
            }

            MensagemRepositorio mensagemRep = new MensagemRepositorio();
            mensagemRep.Cadastrar(mensagem);

            //Retorna mensagem para usuario que login foi efetuado com sucesso
            TempData["valCadastrar"] = "Mensagem enviada com sucesso";
            
            return View();
        }

        [HttpGet]
        public IActionResult ListarMensagem()
        {
            MensagemRepositorio mensagemRep = new MensagemRepositorio();
            ViewData["Mensagens"] = mensagemRep.Listar();
            return View();
        }
    }
}