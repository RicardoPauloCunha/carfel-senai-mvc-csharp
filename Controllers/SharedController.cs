using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckPoint.Controllers
{
    public class SharedController : Controller
    {
        [HttpGet]
        public IActionResult Sair()
        {
            HttpContext.Session.Remove("UsuarioLogId");

            return RedirectToAction("Login", "Usuario");
        }
    }
}