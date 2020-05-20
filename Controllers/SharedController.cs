using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_CarFel_CkeckPoint_Web.Controllers
{
    public class SharedController : Controller
    {
        [HttpGet]
        public IActionResult Sair()
        {
            // Remove a sessão
            HttpContext.Session.Remove("UsuarioLogId");

            // Volta para a pagina de login
            return RedirectToAction("Login", "Usuario");
        }
    }
}