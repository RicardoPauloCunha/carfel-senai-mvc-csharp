using System.Collections.Generic;
using Projeto_CarFel_CheckPoint_Web.Models;

namespace Projeto_CarFel_CheckPoint_Web.Interfaces
{
    public interface IUsuario
    {
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">UsuarioModel</param>
        /// <returns>Retorna um usuario</returns>
        UsuarioModel Cadastrar(UsuarioModel usuario);

        /// <summary>
        /// Lista todos os usuarios cadastrados
        /// </summary>
        /// <returns>Retorno um lista de usuarios</returns>
        List<UsuarioModel> Listar();

        /// <summary>
        /// Efetua o login do usuario caso os dados estejam corretos
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>Retona o usuario correspondente a esses dados</returns>
        UsuarioModel Login(string email, string senha);
    }
}