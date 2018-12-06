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
        /// Busca na lista de depoimentos o usuario correspondente a esse id
        /// </summary>
        /// <param name="id">Id do depoimento</param>
        /// <returns>Retorna um depoimento</returns>
        DepoimentoModel BuscarPorDepoimento(int id);

        /// <summary>
        /// Buscar pela posição em que se encotra o depoimento atraves do id
        /// </summary>
        /// <param name="id">Id do depoimento</param>
        /// <returns>Retorna o indice do depoimento</returns>
        void Reprovar(DepoimentoModel depoimento);

        /// <summary>
        /// Marca o depoimento com aprovado, possibilitando a visualição do mesmo pelos usuarios
        /// </summary>
        /// <param name="id">Do depoimento</param>
        void Aprovar(DepoimentoModel depoimento);
    }
}