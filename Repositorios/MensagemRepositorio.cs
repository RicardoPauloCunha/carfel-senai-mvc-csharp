using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using CheckPoint.Interfaces;
using CheckPoint.Models;

namespace CheckPoint.Repositorios
{
    public class MensagemRepositorio : IMensagem
    {
        public List<MensagemModel> _mensagens;

        public MensagemRepositorio()
        {
            if (File.Exists("FileData/mensagens.dat"))
                _mensagens = Listar();
            else
                _mensagens = new List<MensagemModel>();
        }

        public MensagemModel Cadastrar(MensagemModel mensagem)
        {
            mensagem.Id = _mensagens.Count + 1;
            _mensagens.Add(mensagem);

            SerializerList();

            return mensagem;
        }

        private void SerializerList()
        {
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(memoria, _mensagens);

            File.WriteAllBytes("FileData/mensagens.dat", memoria.ToArray());   
        }

        public List<MensagemModel> Listar()
        {
            if (!File.Exists("FileData/mensagens.dat"))
                return new List<MensagemModel>();
            
            byte[] bytesSerializer = File.ReadAllBytes("FileData/mensagens.dat");
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memoria = new MemoryStream(bytesSerializer);

            return (List<MensagemModel>) serializer.Deserialize(memoria);
        }

        public void Excluir(MensagemModel mensagem) {
            MensagemModel mensagemEncontrada = _mensagens.FirstOrDefault(x => x.Id == mensagem.Id);

            if (mensagemEncontrada == null)
                return;

            mensagemEncontrada.Situacao = "Reprovado";

            SerializerList();
        }

        public MensagemModel BuscarPorId(int id)
        {
            return _mensagens.FirstOrDefault(x => x.Id == id);
        }
    }
}