using Projeto_CarFel_CkeckPoint_Web.Models;
using System.Collections.Generic;

namespace Projeto_CarFel_CkeckPoint_Web.Interfaces
{
    public interface IMensagem
    {
        /// <summary>
        /// Cria uma nova mensagem
        /// </summary>
        /// <param name="mensagem">MensagemModel</param>
        /// <returns>Retorna uma mensagem</returns>
        MensagemModel Cadastrar(MensagemModel mensagem);

        /// <summary>
        /// Lista todos as mensagems cadastradas
        /// </summary>
        /// <returns>Retorna uma lista de mensagems</returns>
        List<MensagemModel> Listar();

        /// <summary>
        /// Busca a mensagem por id
        /// </summary>
        /// <param name="id">Id da mensagem</param>
        /// <returns>Retorna uma mensagem</returns>
        MensagemModel BuscarPorMensagem(int id);

        /// <summary>
        /// Exclui a mensagem
        /// </summary>
        /// <param name="mensagem">mensagem</param>
        void Excluir(MensagemModel mensagem);
    }
}