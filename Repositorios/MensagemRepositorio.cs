using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Projeto_CarFel_CkeckPoint_Web.Models;

namespace Projeto_CarFel_CkeckPoint_Web.Repositorios
{
    public class MensagemRepositorio
    {
        public List<MensagemModel> mensagensSalvos { get; private set; }

        public MensagemRepositorio()
        {
            if (File.Exists("mensagens.dat"))
            {
                mensagensSalvos = Listar();
            }
            else
            {
                mensagensSalvos = new List<MensagemModel>();
            }
        }

        public MensagemModel Cadastrar(MensagemModel mensagem)
        {
            mensagem.Id = mensagensSalvos.Count + 1;
            mensagem.DataCriacao = DateTime.Now;

            mensagensSalvos.Add(mensagem);

            SerializerList();

            return mensagem;
        }

        private void SerializerList()
        {
            //Instancias de classes
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();

            //Serializa e guarda os dados dentro da MemoryStream(memoria)
            serializer.Serialize(memoria, mensagensSalvos);

            //Escreve os bytes no arquivo
            File.WriteAllBytes("mensagens.dat", memoria.ToArray());   
        }

        public List<MensagemModel> Listar()
        {
            //Verifica se o arquivo existe
            if (!File.Exists("mensagens.dat"))
            {
                return new List<MensagemModel>();
            }
            
            //Lê os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("mensagens.dat");
            
            //Desserializa
            BinaryFormatter serializer = new BinaryFormatter();

            //Passa os bytes para a MemoryStream
            MemoryStream memoria = new MemoryStream(bytesSerializer);
            return (List<MensagemModel>) serializer.Deserialize(memoria);
        }

        public void Excluir(MensagemModel mensagem) {
            List<MensagemModel> mensagens = Listar();
            int indice = 0;

            //Procura pela indice em que encontra o id do depoimento e retona-o caso encontrado
            foreach (var msn in mensagens)
            {
                if (msn.Id == mensagem.Id)
                {   
                    //Muda o variavel Situacao e salva os dados
                    mensagensSalvos[indice].Situacao = "Reprovado";
                    SerializerList();
                }
                indice++;
            }
        }

        public MensagemModel BuscarPorMensagem(int id)
        {
            List<MensagemModel> mensagens = Listar();

            foreach (var msn in mensagens)
            {
                if (msn.Id == id)
                {
                    return msn;
                }
            }
            return null;
        }
    }
}