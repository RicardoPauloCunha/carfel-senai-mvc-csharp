using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Projeto_CarFel_CkeckPoint_Web.Interfaces;
using Projeto_CarFel_CkeckPoint_Web.Models;

namespace Projeto_CarFel_CkeckPoint_Web.Repositorios
{
    public class DepoimentoRepositorio : IDepoimento
    {
        public List<DepoimentoModel> depoimentosSalvos {get; private set;}

        public DepoimentoRepositorio()
        {
            if (File.Exists("depoimentos.dat"))
            {
                depoimentosSalvos = Listar();
            }
            else
            {
                depoimentosSalvos = new List<DepoimentoModel>();
            }
        }

        public DepoimentoModel Cadastrar(DepoimentoModel depoimento)
        {
            depoimento.Id = depoimentosSalvos.Count + 1;
            depoimentosSalvos.Add(depoimento);

            SerializerList();
            return depoimento;
        }

        public List<DepoimentoModel> Listar()
        {
            if (!File.Exists("depoimentos.dat"))
            {
                return new List<DepoimentoModel>();
            }

            byte[] bytesSerializer = File.ReadAllBytes("depoimentos.dat");
            MemoryStream memoria = new MemoryStream(bytesSerializer);
            BinaryFormatter serializer = new BinaryFormatter();
            return (List<DepoimentoModel>) serializer.Deserialize(memoria);
        }

        private void SerializerList()
        {
            //Instancias de classes
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();

            //Serializa e guarda os dados dentro da MemoryStream(memoria)
            serializer.Serialize(memoria, depoimentosSalvos);

            //Escreve os bytes no arquivo
            File.WriteAllBytes("depoimentos.dat", memoria.ToArray());
            
        }

        public DepoimentoModel Aprovar(DepoimentoModel depoimento)
        {
            throw new System.NotImplementedException();
        }

        public DepoimentoModel BuscarPorDepoimento(int id)
        {
            List<DepoimentoModel> depoimentos = Listar();
            foreach (var dep in depoimentos)
            {
                if (dep.Id == id)
                {
                    return dep;
                }
            }
            return null;
        }

        public int BuscarPosicaoPorId(int id)
        {
            List<DepoimentoModel> usuarios = Listar();
            int indice = 0;

            foreach (var item in usuarios)
            {
                if (item.Id == id)
                {
                    return indice;
                }
                indice++;
            }
            return -1;
        }

        public void Reprovar(int id)
        {
            int posicao = BuscarPosicaoPorId(id);

            if (posicao >= 0)
            {
                depoimentosSalvos.RemoveAt(posicao);
            }
        }

        public void Aprovar(int id)
        {
            int posicao = BuscarPosicaoPorId(id);

            if (posicao >= 0)
            {
                DepoimentoRepositorio depoimentoRep = new DepoimentoRepositorio();
                DepoimentoModel depoimento = depoimentoRep.BuscarPorDepoimento(id);

                depoimento.Aprovado = true;
                SerializerList();
            }
        }
    }
}