using CheckPoint.Models;
using System.Collections.Generic;

namespace CheckPoint.Interfaces
{
    public interface IDepoimento
    {
        DepoimentoModel Cadastrar(DepoimentoModel depoimento);
        DepoimentoModel BuscarPorId(int id);
        List<DepoimentoModel> Listar();
        void Reprovar(DepoimentoModel depoimento);
        void Aprovar(DepoimentoModel depoimento);
    }
}