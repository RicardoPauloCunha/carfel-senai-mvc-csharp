using System.Collections.Generic;
using Projeto_CarFel_CkeckPoint_Web.Models;

namespace Projeto_CarFel_CkeckPoint_Web.Interfaces
{
    public interface IDepoimento
    {
        /// <summary>
        /// Cria um novo comentario
        /// </summary>
        /// <param name="depoimento">DepoimentoModel</param>
        /// <returns>Retorna um depoimento</returns>
        DepoimentoModel Cadastrar(DepoimentoModel depoimento);

        /// <summary>
        /// Lista todos os depoimentos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de depoimentos</returns>
        List<DepoimentoModel> Listar();

        /// <summary>
        /// Exibi os depoimentos e oferece um sistema para aprova-lo ou reprova-lo
        /// </summary>
        /// <param name="depoimento">DepoimentoModel</param>
        /// <returns>Retorna um depoimento aprovado</returns>
        DepoimentoModel Aprovar(DepoimentoModel depoimento);

        /// <summary>
        /// Busca na lista de depoimentos o usuario correspondente a esse id
        /// </summary>
        /// <param name="id">Id do depoimento</param>
        /// <returns>Retorna um depoimento</returns>
        DepoimentoModel BuscarPorId(int id);

        /// <summary>
        /// Buscar pela posição em que se encotra o depoimento atraves do id
        /// </summary>
        /// <param name="id">Id do depoimento</param>
        /// <returns>Retorna o indice do depoimento</returns>
        int BuscarPosicaoPorId(int id);

        /// <summary>
        /// Excluir o depoimento da lista e da banco de dados
        /// </summary>
        void Excluir();
    }
}