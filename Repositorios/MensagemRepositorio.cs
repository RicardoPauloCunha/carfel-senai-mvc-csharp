using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Projeto_CarFel_CkeckPoint_Web.Interfaces;
using Projeto_CarFel_CkeckPoint_Web.Models;

namespace Projeto_CarFel_CkeckPoint_Web.Repositorios
{
    public class MensagemRepositorio : IMensagem
    {
        public List<MensagemModel> _mensagens;

        public MensagemRepositorio()
        {
            if (File.Exists("filedata/mensagens.dat"))
            {
                _mensagens = Listar();
            }
            else
            {
                _mensagens = new List<MensagemModel>();
            }
        }

        public MensagemModel Cadastrar(MensagemModel mensagem)
        {
            // Atribui os novos valores
            mensagem.Id = _mensagens.Count + 1;
            mensagem.DataCriacao = DateTime.Now;

            // Adiciona na lista
            _mensagens.Add(mensagem);

            // Serealiza os dados
            SerializerList();

            // Retorna as mensagens
            return mensagem;
        }

        private void SerializerList()
        {
            //Instancias de classes
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();

            //Serializa e guarda os dados dentro da MemoryStream(memoria)
            serializer.Serialize(memoria, _mensagens);

            //Escreve os bytes no arquivo
            File.WriteAllBytes("filedata/mensagens.dat", memoria.ToArray());   
        }

        public List<MensagemModel> Listar()
        {
            //Verifica se o arquivo existe
            if (!File.Exists("filedata/mensagens.dat"))
            {
                return new List<MensagemModel>();
            }
            
            //Lê os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("filedata/mensagens.dat");
            
            //Desserializa
            BinaryFormatter serializer = new BinaryFormatter();

            //Passa os bytes para a MemoryStream
            MemoryStream memoria = new MemoryStream(bytesSerializer);

            // Retorna as mensagens
            return (List<MensagemModel>) serializer.Deserialize(memoria);
        }

        public void Excluir(MensagemModel mensagem) {
            // Busca a mensagem
            MensagemModel mensagemEncontrada = _mensagens.FirstOrDefault(x => x.Id == mensagem.Id);

            // Caso não encontre
            if (mensagemEncontrada == null) return;

            // Muda o variavel Situacao e salva os dados
            mensagemEncontrada.Situacao = "Reprovado";

            // Salva os dados
            SerializerList();
        }

        public MensagemModel BuscarPorMensagem(int id)
        {
            // Busca a mensagem por id
            return _mensagens.FirstOrDefault(x => x.Id == id);
        }
    }
}