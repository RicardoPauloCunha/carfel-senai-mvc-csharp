using System.Collections.Generic;
using CheckPoint.Models;

namespace CheckPoint.Interfaces
{
    public interface IUsuario
    {
        UsuarioModel Cadastrar(UsuarioModel usuario);
        UsuarioModel Login(string email, string senha);
        UsuarioModel BuscarPorId(int id);
        List<UsuarioModel> Listar();
    }
}