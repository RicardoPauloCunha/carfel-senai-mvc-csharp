using System;

namespace CheckPoint.Models
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

        public MensagemModel()
        {

        }

        public MensagemModel(string nome, string email, string assunto, string texto, string situacao)
        {
            Nome = nome;
            Email = email;
            Assunto = assunto;
            Texto = texto;
            Situacao = situacao;
            DataCriacao = DateTime.Now;
        }
    }
}