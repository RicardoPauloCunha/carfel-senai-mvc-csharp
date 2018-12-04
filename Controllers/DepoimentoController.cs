using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CkeckPoint_Web.Controllers
{
    public class DepoimentoController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {
            DepoimentoModel depoimento = new DepoimentoModel();
            UsuarioRepositorio usuarioRep = new UsuarioRepositorio();
            DepoimentoRepositorio depoimentoRep = new DepoimentoRepositorio();
            int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));

            depoimento.Usuario = usuarioRep.BuscarPorUser(UsuarioLogId);
            depoimento.DataCriacao = DateTime.Now;
            depoimento.Texto = dados["texto"];
            depoimento.Aprovado = false;

            depoimentoRep.Cadastrar(depoimento);

            TempData["valDepCadastrar"] = "Depoimento Enviado com Sucesso";
            
            return RedirectToAction("Home", "Pagina");
        }
    }
}