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
    }
}