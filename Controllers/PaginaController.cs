using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_CarFel_CheckPoint.Controllers
{
    public class PaginaController : Controller
    {
        //Pagina Home
        [HttpGet]
        public IActionResult Home(){
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Empresa
        [HttpGet]
        public IActionResult Empresa(){
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Preçõs
        [HttpGet]
        public IActionResult Precos(){
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Contato
        [HttpGet]
        public IActionResult Contato(){
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }
    }
}