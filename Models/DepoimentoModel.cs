using System;
using Projeto_CarFel_CheckPoint_Web.Models;

namespace Projeto_CarFel_CkeckPoint_Web.Models
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
    }
}