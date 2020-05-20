using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Projeto_CarFel_CkeckPoint_Web.Interfaces;
using Projeto_CarFel_CkeckPoint_Web.Models;

namespace Projeto_CarFel_CkeckPoint_Web.Repositorios
{
    public class DepoimentoRepositorio : IDepoimento
    {
        public List<DepoimentoModel> _depoimentos;

        public DepoimentoRepositorio()
        {
            if (File.Exists("filedata/depoimentos.dat"))
            {
                _depoimentos = Listar();
            }
            else
            {
                _depoimentos = new List<DepoimentoModel>();
            }
        }

        public DepoimentoModel Cadastrar(DepoimentoModel depoimento)
        {
            //Define os dados do depoimento
            depoimento.Id = _depoimentos.Count + 1;
            depoimento.DataCriacao = DateTime.Now;
            depoimento.Aprovado = false;
            depoimento.Situacao = "Pendente";
            
            //Adiciona o depoimento a lista de usuario salvos
            _depoimentos.Add(depoimento);

            //Serializa a lista de depoimentos
            SerializerList();

            //Retorne depoimento
            return depoimento;
        }

        public List<DepoimentoModel> Listar()
        {   
            //Verifica se o arquivo já existe
            if (!File.Exists("filedata/depoimentos.dat"))
            {
                //Caso não, cria uma nova
                return new List<DepoimentoModel>();
            }

            //Lê os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("filedata/depoimentos.dat");

            //Desserializa
            MemoryStream memoria = new MemoryStream(bytesSerializer);

            //Passa os bytes para a MemoryStream
            BinaryFormatter serializer = new BinaryFormatter();

            // Retorna os depoimentos
            return (List<DepoimentoModel>) serializer.Deserialize(memoria);
        }

        private void SerializerList()
        {
            //Instancias de classes
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();

            //Serializa e guarda os dados dentro da MemoryStream(memoria)
            serializer.Serialize(memoria, _depoimentos);

            //Escreve os bytes no arquivo
            File.WriteAllBytes("filedata/depoimentos.dat", memoria.ToArray());
        }

        public DepoimentoModel BuscarPorDepoimento(int id)
        {
            // Busca o depoimento por id
            return _depoimentos.FirstOrDefault(x => x.Id == id);
        }

        public void Reprovar(DepoimentoModel depoimento) {
            // Busca o depoimento
            DepoimentoModel depoimentoEncontrado = _depoimentos.FirstOrDefault(x => x.Id == depoimento.Id);

            // Caso não encontre
            if (depoimentoEncontrado == null) return;

            // Muda o variavel Situacao e salva os dados
            depoimentoEncontrado.Situacao = "Reprovado";

            // Salva
            SerializerList();
        }

        public void Aprovar(DepoimentoModel depoimento)
        {
            // Busca o depoimento
            DepoimentoModel depoimentoEncontrado = _depoimentos.FirstOrDefault(x => x.Id == depoimento.Id);

            // Caso não encontre
            if (depoimentoEncontrado == null) return;

            // Muda o variavel Situacao e salva os dados
            depoimentoEncontrado.Situacao = "Aprovado";

            // Salva
            SerializerList();
        }
    }
}