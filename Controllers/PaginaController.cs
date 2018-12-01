using Microsoft.AspNetCore.Mvc;

namespace Projeto_CarFel_CheckPoint.Controllers
{
    public class PaginaController : Controller
    {
        [HttpGet]
        public IActionResult Home(){
            return View();
        }

        [HttpGet]
        public IActionResult Empresa(){
            return View();
        }

        [HttpGet]
        public IActionResult Precos(){
            return View();
        }

        [HttpGet]
        public IActionResult Contato(){
            return View();
        }
    }
}