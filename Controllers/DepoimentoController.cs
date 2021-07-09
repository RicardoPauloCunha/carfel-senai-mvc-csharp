using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Models;
using CheckPoint.Repositorios;
using CheckPoint.Util;
using CheckPoint.Interfaces;

namespace CheckPoint.Controllers
{
    public class DepoimentoController : Controller
    {
        private readonly IDepoimento _depoimentoRepositorio;
        private readonly ValidacaoUtil _validacaoUtil;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public DepoimentoController()
        {
            _depoimentoRepositorio = new DepoimentoRepositorio();
            _validacaoUtil = new ValidacaoUtil();
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public bool VerificarTexto(string texto)
        {
            bool testoValido = _validacaoUtil.ValidarTexto(texto);

            if (!testoValido)
            {
                TempData["MensengeValT"] = "Insira um Texto para pode enviar o Depoimento";
                return false;
            }

            return true;
        }
        
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {
            bool textoValido = VerificarTexto(dados["texto"]);

            if (textoValido)
            {
                int usuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(usuarioLogId);

                DepoimentoModel depoimentoModel = new DepoimentoModel(dados["texto"], usuario);
                _depoimentoRepositorio.Cadastrar(depoimentoModel);

                TempData["valDepCadastrar"] = "Depoimento Enviado com Sucesso. Será avalidado pelo admin antes de ser exibido";
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                ViewBag.UserLog = UsuarioLogId;

                UsuarioModel usuarioLog = _usuarioRepositorio.BuscarPorId(UsuarioLogId);
                ViewBag.UsuarioLogN = usuarioLog.Nome;
            }
            else
            {
                ViewBag.UserLog = null;
            }

            ViewData["Depoimentos"] = _depoimentoRepositorio.Listar();
            return View();
        }
        
        [HttpGet]
        public IActionResult Reprovar(int id)
        {
            DepoimentoModel depoimento = _depoimentoRepositorio.BuscarPorId(id);

            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }
            
            _depoimentoRepositorio.Reprovar(depoimento);

            TempData["AvaliacaoSucesso"] = "Depoimento Excluido da Lista";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Aprovar(int id)
        {
            DepoimentoModel depoimento = _depoimentoRepositorio.BuscarPorId(id);

            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }

            _depoimentoRepositorio.Aprovar(depoimento);

            TempData["AvaliacaoSucesso"] = "Depoimento Aprovado";
            return RedirectToAction("Listar");
        }
    }
}