using CheckPoint.Models;
using System.Collections.Generic;

namespace CheckPoint.Interfaces
{
    public interface IMensagem
    {
        MensagemModel Cadastrar(MensagemModel mensagem);
        MensagemModel BuscarPorId(int id);
        List<MensagemModel> Listar();
        void Excluir(MensagemModel mensagem);
    }
}