using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Interfaces;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CheckPoint_Web.Util;
using Projeto_CarFel_CkeckPoint_Web.Interfaces;
using Projeto_CarFel_CkeckPoint_Web.Models;
using Projeto_CarFel_CkeckPoint_Web.Repositorios;

namespace Projeto_CarFel_CheckPoint.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ValidacaoUtil _validacaoUtil;
        private readonly IUsuario _usuarioRepositorio;
        private readonly IMensagem _mensagemRepositorio;

        public PaginaController()
        {
            _validacaoUtil = new ValidacaoUtil();
            _usuarioRepositorio = new UsuarioRepositorio();
            _mensagemRepositorio = new MensagemRepositorio();
        }

        //Pagina Home
        [HttpGet]
        public IActionResult Home()
        {
            // Pega o id do usuário
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");

            return View();
        }

        //Pagina Empresa
        [HttpGet]
        public IActionResult Empresa()
        {
            // Pega o id do usuário
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");

            return View();
        }

        //Pagina Preçõs
        [HttpGet]
        public IActionResult Precos()
        {
            // Pega o id do usuário
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");

            return View();
        }

        //Validação do Email
        public bool ValidarEmail(string email)
        {
            // Valida o email
            bool valE = _validacaoUtil.ValEmail(email);

            // Caso não seja valido
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
            // Verifica o texto
            bool valS = _validacaoUtil.valTexto(texto);

            // Caso não seja valido
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
            // Verifica o assunto
            bool valS = _validacaoUtil.valTexto(Assunto);

            // Caso não seja valido
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
            // Caso esteja logado
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                // Recupera o id
                int UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));

                // Caso seja o admin
                if (UsuarioLogId == 1)
                {
                    return RedirectToAction("ListarMensagem", "Pagina");                    
                }

                // Atribui os dados do usuário
                ViewData["UsuarioLog"] = _usuarioRepositorio.BuscarPorUser(UsuarioLogId);
            }

            // Recupera o id do usuário
            ViewBag.UserLog = HttpContext.Session.GetString("UsuarioLogId");

            return View();
        }


        //Função de Cadastrar Mensagens
        [HttpPost]
        public IActionResult Contato(IFormCollection dados)
        {  
            // Declara a variavel
            int UsuarioLogId = 0;

            // Caso esteja logado
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                // Recupera e atribui
                UsuarioLogId = int.Parse(HttpContext.Session.GetString("UsuarioLogId"));
                ViewBag.UserLog = UsuarioLogId;
            }
            
            //Validações
            bool ValE = true;

            // Valida o email
            if (HttpContext.Session.GetString("UsuarioLogId") == null)
            {
                ValE = ValidarEmail(dados["email"]);
            }
            
            // Valida o texto e o assutno
            bool ValA = ValidarAssunto(dados["assunto"]);
            bool ValT = ValidarTexto(dados["texto"]);

            // Caso tenha algum erro
            if (!ValE || !ValA || !ValT)
            {
                TempData["FalhaCadMen"] = "Falha ao enviar a mensagem. Dados inválidos";
                return View();
            }

            // Cria a mensagem
            MensagemModel mensagem = new MensagemModel(dados["nome"], dados["email"], dados["assunto"], dados["texto"], "Pedente");

            // Caso não tenha feito login
            if (HttpContext.Session.GetString("UsuarioLogId") != null)
            {
                // Busca o usuário
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorUser(UsuarioLogId);

                // Atribui os dados da mensagem
                mensagem.Nome = usuario.Nome;
                mensagem.Email = usuario.Email;

                // Atribui no log
                ViewData["UsuarioLog"] = usuario;
            }
            
            _mensagemRepositorio.Cadastrar(mensagem);

            // Retorna mensagem para usuario que login foi efetuado com sucesso
            TempData["SucessoCadMen"] = "Mensagem enviada com sucesso";
            
            return View();
        }

        //Função de listas todas as Mensagens
        [HttpGet]
        public IActionResult ListarMensagem()
        {
            // Lista todos os produtos
            ViewData["Mensagens"] = _mensagemRepositorio.Listar();

            return View();
        }

        //Função Excluir Mensagens
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            //Procura pelo mensagem
            MensagemModel mensagem = _mensagemRepositorio.BuscarPorMensagem(id);

            //Caso não encontrado
            if (mensagem == null)
            {
                // Retorna erro
                TempData["AvaliacaoSucesso"] = "Mensagem não encontrada";
                return View();
            }
            
            // Exclui a mensagem
            _mensagemRepositorio.Excluir(mensagem);

            //Retorna mensagem para user e redireciona ele para a pagina de depoimentos
            TempData["AvaliacaoSucesso"] = "Mensagem Excluida da Lista";

            return RedirectToAction("ListarMensagem");
        }
    }
}