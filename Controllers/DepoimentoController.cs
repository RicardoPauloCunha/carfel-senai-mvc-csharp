using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CheckPoint_Web.Util;
using Projeto_CarFel_CkeckPoint_Web.Interfaces;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CkeckPoint_Web.Controllers
{
    public class DepoimentoController : Controller
    {
        //Construtor
        private readonly IDepoimento _depoimentoRepositorio;
        private readonly ValidacaoUtil _validacaoUtil;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public DepoimentoController()
        {
            //Polimorfismo
            _depoimentoRepositorio = new DepoimentoRepositorio();
            _validacaoUtil = new ValidacaoUtil();
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        //validação Texto
        public bool ValTexto(string texto)
        {
            // Valida o texto
            bool valT = _validacaoUtil.valTexto(texto);

            // Caso não seja válido
            if (!valT)
            {
                // Retorna erro
                TempData["MensengeValT"] = "Insira um Texto para pode enviar o Depoimento";
                return false;
            }

            return true;
        }
        
        //Função Cadastrar Depoimento 
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {
            // Valida o texto
            bool valT = ValTexto(dados["texto"]);

            //Pega o id do Usuario Logado
            int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
            
            //Caso os dados estejam certos, cadastra depoimento
            if (valT)
            {
                // Declara o depoimento
                DepoimentoModel depoimentoModel = new DepoimentoModel();

                //Procura pelo usuario correspondênte ao depoimento atraves do id
                depoimentoModel.Usuario = _usuarioRepositorio.BuscarPorUser(UsuarioLogId);

                // Atribui os dados
                depoimentoModel.Texto = dados["texto"];

                // Cadastra o depoimento
                _depoimentoRepositorio.Cadastrar(depoimentoModel);

                //Retorna mensagem para usuario que cadastro do dep foi efetuado com sucesso
                TempData["valDepCadastrar"] = "Depoimento Enviado com Sucesso. Será avalidado pelo admin antes de ser exibido";
            }

            //Retorna para a página de depoimentos
            return RedirectToAction("Listar");
        }

        //Função Listar Depoimentos
        [HttpGet]
        public IActionResult Listar()
        {

            //Pega o id do usuario que esta logado
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                // Recupera o id e adicina na bag
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                ViewBag.UserLog = UsuarioLogId;

                // Procura pelo usuario correspondênte ao id e adiciona na bag
                UsuarioModel usuarioLog = _usuarioRepositorio.BuscarPorUser(UsuarioLogId);
                ViewBag.UsuarioLogN = usuarioLog.Nome;
            }
            else
            {
                ViewBag.UserLog = null;
            }

            //Lista todos os depoimentos
            ViewData["Depoimentos"] = _depoimentoRepositorio.Listar();

            return View();
        }
        
        //Função Reprovar Depoimentos
        [HttpGet]
        public IActionResult Reprovar(int id)
        {
            //Procura pelo depoimento
            DepoimentoModel depoimento = _depoimentoRepositorio.BuscarPorDepoimento(id);

            //Caso não encontrado
            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }
            
            //Caso encontrado
            _depoimentoRepositorio.Reprovar(depoimento);

            //Retorna mensagem para user e redireciona ele para a pagina de depoimentos
            TempData["AvaliacaoSucesso"] = "Depoimento Excluido da Lista";
            return RedirectToAction("Listar");
        }

        //Função Aprovar Depoimento
        [HttpGet]
        public IActionResult Aprovar(int id)
        {
            //Procura pelo depoimento
            DepoimentoModel depoimento = _depoimentoRepositorio.BuscarPorDepoimento(id);

            //Caso não encontrado
            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }

            //Caso encontrado
            _depoimentoRepositorio.Aprovar(depoimento);

            //Retorna mensagem para user e redireciona ele para a pagina de depoimentos
            TempData["AvaliacaoSucesso"] = "Depoimento Aprovado";
            return RedirectToAction("Listar");
        }
    }
}