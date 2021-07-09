using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using CheckPoint.Interfaces;
using CheckPoint.Models;

namespace CheckPoint.Repositorios
{
    public class DepoimentoRepositorio : IDepoimento
    {
        public List<DepoimentoModel> _depoimentos;

        public DepoimentoRepositorio()
        {
            if (File.Exists("FileData/depoimentos.dat"))
                _depoimentos = Listar();
            else
                _depoimentos = new List<DepoimentoModel>();
        }

        public DepoimentoModel Cadastrar(DepoimentoModel depoimento)
        {
            depoimento.Id = _depoimentos.Count + 1;
            _depoimentos.Add(depoimento);

            SerializerList();

            return depoimento;
        }

        public List<DepoimentoModel> Listar()
        {   
            if (!File.Exists("FileData/depoimentos.dat"))
                return new List<DepoimentoModel>();

            byte[] bytesSerializer = File.ReadAllBytes("FileData/depoimentos.dat");
            MemoryStream memoria = new MemoryStream(bytesSerializer);
            BinaryFormatter serializer = new BinaryFormatter();

            return (List<DepoimentoModel>) serializer.Deserialize(memoria);
        }

        private void SerializerList()
        {
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(memoria, _depoimentos);

            File.WriteAllBytes("FileData/depoimentos.dat", memoria.ToArray());
        }

        public DepoimentoModel BuscarPorId(int id)
        {
            return _depoimentos.FirstOrDefault(x => x.Id == id);
        }

        public void Reprovar(DepoimentoModel depoimento) {
            DepoimentoModel depoimentoEncontrado = _depoimentos.FirstOrDefault(x => x.Id == depoimento.Id);

            if (depoimentoEncontrado == null)
                return;

            depoimentoEncontrado.Situacao = "Reprovado";

            SerializerList();
        }

        public void Aprovar(DepoimentoModel depoimento)
        {
            DepoimentoModel depoimentoEncontrado = _depoimentos.FirstOrDefault(x => x.Id == depoimento.Id);

            if (depoimentoEncontrado == null)
                return;

            depoimentoEncontrado.Situacao = "Aprovado";

            SerializerList();
        }
    }
}