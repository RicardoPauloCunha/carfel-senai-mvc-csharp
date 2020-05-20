using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_CarFel_CheckPoint_Web.Interfaces;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Repositorios;
using Projeto_CarFel_CheckPoint_Web.Util;

namespace Projeto_CarFel_CheckPoint_Web.Controllers
{
    public class UsuarioController : Controller
    {
        //Construtor
        private readonly IUsuario _usuarioRepositorio;
        private readonly ValidacaoUtil _validacaoUtil;
        public UsuarioController()
        {
            //Polimorfismo
            _usuarioRepositorio = new UsuarioRepositorio();
            _validacaoUtil = new ValidacaoUtil();
        }

        //Validação do Nome
        public bool ValidarNome(string nome)
        {
            // Verifica se o nome é valido
            bool valN = _validacaoUtil.ValNome(nome);

            // Caso não seja
            if (!valN)
            {
                // Coloca na variavel de erro
                TempData["MensengeValN"] = "Insira o seu nome completo (Mínimo 8 caracteres)";
                return false;
            }

            return true;
        }

        //Validação do Email
        public bool ValidarEmail(string email)
        {
            // Verifica se o email é valido
            bool valE = _validacaoUtil.ValEmail(email);

            // Caso não seja
            if (!valE)
            {
                // Coloca na variavel de erro
                TempData["MensengeValE"] = "Email deve conter @ e .";
                return false;
            }
            return true;
        }

        //Verfica se email já existe
        public bool ValidarEmailExist(string email)
        {
            // Verifica se o email já existe
            bool ValEE = _validacaoUtil.ValEmailExist(email);

            // Caso exista
            if (!ValEE)
            {
                TempData["MensengeValE"] = "Email já cadastrado";
                return false;
            }
            return true;
        }

        //Validação da Senha
        public bool ValidarSenha(string senha)
        {
            // Verifica o tamanho da senha
            bool valS = _validacaoUtil.ValSenha(senha);

            // Caso não tenha o tamanho nessário
            if (!valS)
            {
                TempData["MensengeValS"] = "Senha deve conter pelo menos 5 caracteres";
                return false;
            }

            return true;
        }

        //Validação da Senha 2
        public bool ValidarSenha2(string senha, string senha2)
        {
            // Confima a senha
            bool valSs = _validacaoUtil.ValSenha2(senha, senha2);

            // Caso não sejam iguais
            if (!valSs)
            {
                TempData["MensengeValSs"] = "Senha incorreta";
                return false;
            }
            return true;
        }

        // Função cadastrar
        [HttpGet]
        public IActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection dados)
        {

            // Valida os dados
            bool valN = ValidarNome(dados["nome"]);
            bool valE = ValidarEmail(dados["email"]);
            bool ValEE = ValidarEmailExist(dados["email"]);
            bool valS = ValidarSenha(dados["senha"]);
            bool valSs = ValidarSenha2(dados["senha"], dados["senha2"]);

            //Caso esteja certo cadastra usuario
            if (valN && valE && ValEE && valS && valSs)
            {
                //Senha criptografada
                HashUtil hashUtil = new HashUtil();
                string senhaHash = hashUtil.CriptografarSenha(dados["senha"]);

                // Cria o usuário
                UsuarioModel usuario = new UsuarioModel(dados["nome"], dados["email"], senhaHash, "Usuario");

                // Cadastra o usuário
                _usuarioRepositorio.Cadastrar(usuario);
                
                //Retorna mensagem para usuario que login foi efetuado com sucesso
                TempData["valCadastrar"] = "Usuario cadastrado com sucesso";
            }
            else
            {
                //Caso contrario retorna mensagem de falha
                TempData["IvalCadastrar"] = "Falha ao cadastrar. Dados inválidos";
            }
            
            return View();
        }

        //Função Logar
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection dados)
        {
            //Validação do email e senha
            bool valE = ValidarEmail(dados["email"]);
            bool valS = ValidarSenha(dados["senha"]);

            // Caso esteja tudo certo efetua o processo de login
            if (valE && valS)
            {
                // Faz login
                UsuarioModel usuario = _usuarioRepositorio.Login(dados["email"], dados["senha"]);    

                //Verifica se o usuario foi encontrado       
                if (usuario != null)
                {
                    //Caso encontrado adiciona ele a uma session
                    HttpContext.Session.SetString("UsuarioLogId", usuario.Id.ToString());

                    //Retorna para a pagina home
                    return RedirectToAction("Home", "Pagina");
                }
                else
                {
                    //Caso não encontrado retorna mensagem de erro
                    TempData["MensValLogin"] = "Email ou Senha Incorretos";
                }
            }
            else
            {
                //Caso dados estejam incorretos
                TempData["MensValLogin"] = "Falha ao Logar. Dados Inválidos";
            }
            
            return View();
        }
    }
}