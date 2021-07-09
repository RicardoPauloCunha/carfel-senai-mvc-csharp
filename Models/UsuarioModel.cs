using System;

namespace CheckPoint.Models
{
    [Serializable]
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public UsuarioModel()
        {

        }

        public UsuarioModel(int id, string nome, string email, string senha, string tipo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }

        public UsuarioModel(string nome, string email, string senha, string tipo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }
    }
}