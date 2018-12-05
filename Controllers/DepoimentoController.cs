using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CkeckPoint_Web.Interfaces;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CkeckPoint_Web.Controllers
{
    public class DepoimentoController : Controller
    {
        private IDepoimento DepoimentoRepositorio {get; set;}

        public DepoimentoController()
        {
            DepoimentoRepositorio = new DepoimentoRepositorio();
        }
        
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
            int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));

            depoimento.Usuario = usuarioRep.BuscarPorUser(UsuarioLogId);
            depoimento.DataCriacao = DateTime.Now;
            depoimento.Texto = dados["texto"];
            depoimento.Aprovado = false;

            DepoimentoRepositorio.Cadastrar(depoimento);

            TempData["valDepCadastrar"] = "Depoimento Enviado com Sucesso";
            
            return RedirectToAction("Home", "Pagina");
        }

        [HttpGet]
        public IActionResult Listar()
        {
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
            ViewData["Depoimentos"] = DepoimentoRepositorio.Listar();
            return View();
        }

        [HttpGet]
        public IActionResult Reprovar(int id)
        {
            DepoimentoRepositorio.Reprovar(id);
            TempData["AvaliacaoSucesso"] = "Depoimento Excluido da lista de Usuarios";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Aprovar(int id)
        {
            DepoimentoModel depoimento = DepoimentoRepositorio.BuscarPorDepoimento(id);

            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }

            DepoimentoRepositorio.Aprovar(depoimento);

            TempData["AvaliacaoSucesso"] = "Depoimento Aprovado";
            return RedirectToAction("Listar");
        }
    }
}