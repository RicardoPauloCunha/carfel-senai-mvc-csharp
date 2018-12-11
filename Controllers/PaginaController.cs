using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CheckPoint_Web.Util;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CheckPoint.Controllers
{
    public class PaginaController : Controller
    {
        //Pagina Home
        [HttpGet]
        public IActionResult Home()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Empresa
        [HttpGet]
        public IActionResult Empresa()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Pagina Preçõs
        [HttpGet]
        public IActionResult Precos()
        {
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }

        //Validações
        ValidacaoUtil val = new ValidacaoUtil();

        //Validação do Email
        public bool ValidarEmail(string email)
        {
            bool valE = val.ValEmail(email);
            if (!valE)
            {
                TempData["MensengeValE"] = "Email deve conter @ e .";
                return false;
            }
            return true;
        }

        //Validação da Senha
        public bool ValidarTexto(string texto)
        {
            bool valS = val.valTexto(texto);
            if (!valS)
            {
                TempData["MensengeValT"] = "Insira um texto para poder enviar a mensagem";
                return false;
            }
            return true;
        }

        //Validar Assunto
        public bool ValidarAssunto(string Assunto)
        {
            bool valS = val.valTexto(Assunto);
            if (!valS)
            {
                TempData["MensengeValA"] = "Insira um assunto para poder enviar a mensagem";
                return false;
            }
            return true;
        }

        //Pagina Contato
        [HttpGet]
        public IActionResult Contato()
        {
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                if (UsuarioLogId == 1)
                {
                    return RedirectToAction("ListarMensagem", "Pagina");                    
                }
                UsuarioRepositorio usuarioRep = new UsuarioRepositorio();

                ViewData["UsuarioLog"] = usuarioRep.BuscarPorUser(UsuarioLogId);
            }

            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");
            return View();
        }


        //Função de Cadastrar Mensagens
        [HttpPost]
        public IActionResult Contato(IFormCollection dados)
        {  
            int UsuarioLogId = 0;
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                ViewBag.UserLog = UsuarioLogId;
            }
            
            //Validações
            bool ValE = true;
            if (HttpContext.Session.GetString("UsuarioLogId") == null)
            {
                ValE = ValidarEmail(dados["email"]);
            }
            
            bool ValA = ValidarAssunto(dados["assunto"]);
            bool ValT = ValidarTexto(dados["texto"]);

            if (!ValE || !ValA || !ValT)
            {
                TempData["FalhaCadMen"] = "Falha ao enviar a mensagem";
                return View();
            }

            MensagemModel mensagem = new MensagemModel();
            mensagem.Nome = dados["nome"];
            mensagem.Email = dados["email"];
            mensagem.Assunto = dados["assunto"];
            mensagem.Texto = dados["texto"];
            mensagem.Situacao = "pedente";

            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                UsuarioRepositorio usuarioRep = new UsuarioRepositorio();

                UsuarioModel usuario = usuarioRep.BuscarPorUser(UsuarioLogId);
                mensagem.Nome = usuario.Nome;
                mensagem.Email = usuario.Email;
                ViewData["UsuarioLog"] = usuario;
            }

            MensagemRepositorio mensagemRep = new MensagemRepositorio();
            mensagemRep.Cadastrar(mensagem);

            //Retorna mensagem para usuario que login foi efetuado com sucesso
            TempData["SucessoCadMen"] = "Mensagem enviada com sucesso";
            
            return View();
        }

        //Função de listas todas as Mensagens
        [HttpGet]
        public IActionResult ListarMensagem()
        {
            MensagemRepositorio mensagemRep = new MensagemRepositorio();
            ViewData["Mensagens"] = mensagemRep.Listar();
            return View();
        }

        //Função Excluir Mensagens
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            //Procura pelo mensagem
            MensagemRepositorio mensagemRep = new MensagemRepositorio();
            MensagemModel mensagem = mensagemRep.BuscarPorMensagem(id);

            //Caso não encontrado
            if (mensagem == null)
            {
                TempData["AvaliacaoSucesso"] = "Mensagem não encontrada";
                return View();
            }
            
            //Caso encontrado
            mensagemRep.Excluir(mensagem);

            //Retorna mensagem para user e redireciona ele para a pagina de depoimentos
            TempData["AvaliacaoSucesso"] = "Mensagem Excluida da Lista";
            return RedirectToAction("ListarMensagem");
        }
    }
}