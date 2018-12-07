using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_CarFel_CkeckPoint_Web.Controllers
{
    public class SharedController : Controller
    {
        [HttpGet]
        public IActionResult Sair()
        {
            HttpContext.Session.Remove("UsuarioLogId");
            return RedirectToAction("Home", "Pagina");
        }
    }
}