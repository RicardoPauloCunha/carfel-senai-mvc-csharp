using System;
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
            //Define os dados do depoimento
            depoimento.Id = depoimentosSalvos.Count + 1;
            depoimento.DataCriacao = DateTime.Now;
            depoimento.Aprovado = false;
            depoimento.Situacao = "Pendente";
            
            //Adiciona o depoimento a lista de usuario salvos
            depoimentosSalvos.Add(depoimento);

            //Serializa a lista de depoimentos
            SerializerList();

            //Retorne depoimento
            return depoimento;
        }

        public List<DepoimentoModel> Listar()
        {   
            //Verifica se o arquivo já existe
            if (!File.Exists("depoimentos.dat"))
            {
                //Caso não, cria uma nova
                return new List<DepoimentoModel>();
            }
            //Lê os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("depoimentos.dat");
            //Desserializa
            MemoryStream memoria = new MemoryStream(bytesSerializer);
            //Passa os bytes para a MemoryStream
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

        public DepoimentoModel BuscarPorDepoimento(int id)
        {
            List<DepoimentoModel> depoimentos = Listar();

            //Procura por depoimento através do id e retona-o caso encontradom, e null caso não
            foreach (var dep in depoimentos)
            {
                if (dep.Id == id)
                {
                    return dep;
                }
            }
            return null;
        }
        public void Reprovar(DepoimentoModel depoimento) {
            List<DepoimentoModel> depoimentos = Listar();
            int indice = 0;

            //Procura pela indice em que encontra o id do depoimento e retona-o caso encontrado
            foreach (var dep in depoimentos)
            {
                if (dep.Id == depoimento.Id)
                {
                    // depoimentosSalvos[indice].Aprovado = true;
                    
                    //Muda o variavel Situacao e salva os dados
                    depoimentosSalvos[indice].Situacao = "reprovado";
                    SerializerList();
                }
                indice++;
            }
        }
        // public void Reprovar(int id)
        // {
        //     int posicao = BuscarPosicaoPorId(id);

        //     if (posicao >= 0)
        //     {
        //         depoimentosSalvos.RemoveAt(posicao);
        //     }

        //     SerializerList();
        // }

        public void Aprovar(DepoimentoModel depoimento)
        {
            List<DepoimentoModel> depoimentos = Listar();
            int indice = 0;

            //Procura pela indice em que encontra o id do depoimento e retona-o caso encontrado
            foreach (var dep in depoimentos)
            {
                if (dep.Id == depoimento.Id)
                {
                    // depoimentosSalvos[indice].Aprovado = true;

                    //Muda o variavel Situacao e salva os dados
                    depoimentosSalvos[indice].Situacao = "Aprovado";
                    SerializerList();
                }
                indice++;
            }
        }
    }
}