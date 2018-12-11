using System;

namespace Projeto_CarFel_CkeckPoint_Web.Models
{
    [Serializable]
    public class MensagemModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Situacao { get; set; }
    }
}