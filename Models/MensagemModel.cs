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

        public MensagemModel()
        {

        }

        public MensagemModel(int id, string nome, string email, string assunto, string texto, DateTime dataCriacao, string situacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Assunto = assunto;
            Texto = texto;
            DataCriacao = dataCriacao;
            Situacao = situacao;
        }

        public MensagemModel(string nome, string email, string assunto, string texto, string situacao)
        {
            Nome = nome;
            Email = email;
            Assunto = assunto;
            Texto = texto;
            Situacao = situacao;
        }
    }
}