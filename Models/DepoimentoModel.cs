using System;
using CheckPoint.Models;

namespace CheckPoint.Models
{
    [Serializable]
    public class DepoimentoModel
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Situacao { get; set; }
        public bool Aprovado { get; set; }
        public UsuarioModel Usuario { get; set; }
        public DateTime DataCriacao { get; set; }

        public DepoimentoModel()
        {

        }

        public DepoimentoModel(string texto, UsuarioModel usuario)
        {
            Texto = texto;
            Usuario = usuario;
            DataCriacao = DateTime.Now;
            Aprovado = false;
            Situacao = "Pendente";
        }
    }
}