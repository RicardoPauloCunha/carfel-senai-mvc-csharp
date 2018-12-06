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
        private IDepoimento DepoimentoRepositorio {get; set;}

        public DepoimentoController()
        {
            //Polimorfismo
            DepoimentoRepositorio = new DepoimentoRepositorio();
        }

        //validação Texto
        public bool ValTexto(string texto)
        {
            ValidacaoUtil val = new ValidacaoUtil();
            bool valT = val.valTexto(texto);
            if (!valT)
            {
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
            DepoimentoModel depoimento = new DepoimentoModel();
            UsuarioRepositorio usuarioRep = new UsuarioRepositorio();
            bool valT = ValTexto(dados["texto"]);

            //Pega o id do Usuario Logado
            int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
            
            //Caso os dados estejam certos, cadastra depoimento
            if (valT)
            {
                //Procura pelo usuario correspondênte ao depoimento atraves do id
                depoimento.Usuario = usuarioRep.BuscarPorUser(UsuarioLogId);

                depoimento.Texto = dados["texto"];
                DepoimentoRepositorio.Cadastrar(depoimento);

                //Retorna mensagem para usuario que cadastro do dep foi efetuado com sucesso
                TempData["valDepCadastrar"] = "Depoimento Enviado com Sucesso";
            }

            //Retorna para a página de depoimentos
            return RedirectToAction("Listar");
        }

        //Função Listar Depoimentos
        [HttpGet]
        public IActionResult Listar()
        {
            UsuarioRepositorio usuario = new UsuarioRepositorio();
            int UsuarioLogId = 0;

            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                //Pega o id do usuario que esta logado
                UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));

                //Procura pelo usuario correspondênte ao id
                UsuarioModel usuarioLog = usuario.BuscarPorUser(UsuarioLogId);
                ViewBag.UsuarioLogN = usuarioLog.Nome;
            }
            
            ViewBag.UserLog = UsuarioLogId;
            
            //Lista todos os depoimentos
            ViewData["Depoimentos"] = DepoimentoRepositorio.Listar();
            return View();
        }

        //Função Reprovar Depoimentos
        [HttpGet]
        public IActionResult Reprovar(int id)
        {
            //Procura pelo depoimento
            DepoimentoModel depoimento = DepoimentoRepositorio.BuscarPorDepoimento(id);

            //Caso não encontrado
            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }
            
            //Caso encontrado
            DepoimentoRepositorio.Reprovar(depoimento);

            //Retorna mensagem para user e redireciona ele para a pagina de depoimentos
            TempData["AvaliacaoSucesso"] = "Depoimento Excluido da Lista";
            return RedirectToAction("Listar");
        }

        // Metodo que exclui permanentemente o depoimento do banco de dados 
        // public IActionResult Reprovar(int id)
        // {
        //     DepoimentoRepositorio.Reprovar(id);
        //     TempData["AvaliacaoSucesso"] = "Depoimento Excluido da Lista";
        //     return RedirectToAction("Listar");
        // }

        //Função Aprovar Depoimento
        [HttpGet]
        public IActionResult Aprovar(int id)
        {
            //Procura pelo depoimento
            DepoimentoModel depoimento = DepoimentoRepositorio.BuscarPorDepoimento(id);

            //Caso não encontrado
            if (depoimento == null)
            {
                TempData["AvaliacaoSucesso"] = "Depoimento não encontrado";
                return View();
            }

            //Caso encontrado
            DepoimentoRepositorio.Aprovar(depoimento);

            //Retorna mensagem para user e redireciona ele para a pagina de depoimentos
            TempData["AvaliacaoSucesso"] = "Depoimento Aprovado";
            return RedirectToAction("Listar");
        }
    }
}