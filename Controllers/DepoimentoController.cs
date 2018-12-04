using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Models;
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

        [HttpGet]
        public IActionResult Listar()
        {
            DepoimentoRepositorio depoimento = new DepoimentoRepositorio();
            UsuarioRepositorio usuario = new UsuarioRepositorio();
            int UsuarioLogId = 0;

            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                UsuarioModel usuarioLog = usuario.BuscarPorUser(UsuarioLogId);
                ViewBag.UsuarioLogN = usuarioLog.Nome;
            }
            else
            {
                ViewBag.UsuarioLogN = "User";
            }
            
            ViewBag.UserLog = UsuarioLogId;
            ViewData["Depoimentos"] = depoimento.Listar();
            return View();
        }
    }
}