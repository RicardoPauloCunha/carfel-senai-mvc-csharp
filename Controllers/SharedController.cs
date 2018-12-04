using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CkeckPoint_Web.Controllers
{
    public class SharedController : Controller
    {
        [HttpGet]
        public ActionResult MasterPageLogado() 
        {
            DepoimentoRepositorio depoimento = new DepoimentoRepositorio();
            List<DepoimentoModel> depoimentos = depoimento.Listar();
            ViewData["Depoimentos"] = depoimentos;
            return View(); 
        }
    }
}