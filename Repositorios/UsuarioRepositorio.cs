using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Projeto_CarFel_CheckPoint_Web.Interfaces;
using Projeto_CarFel_CheckPoint_Web.Models;

namespace Projeto_CarFel_CheckPoint_Web.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        public List<UsuarioModel> usuariosSalvos { get; private set; }

        public UsuarioRepositorio()
        {
            if (File.Exists("usuarios.dat"))
            {
                usuariosSalvos = Listar();
            }
            else
            {
                usuariosSalvos = new List<UsuarioModel>();
            }
        }
        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            //Incrementa o id do usuario
            usuario.Id = usuariosSalvos.Count + 1;

            //Adiciona a lista de usuariosSalvos
            usuariosSalvos.Add(usuario);

            //Serializa a lista de usuarios
            SerializerList();

            //Retorna o usuario (não sei pq)
            return usuario;
        }

        private void SerializerList()
        {
            //Instancias de classes
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();

            //Serializa e guarda os dados dentro da MemoryStream(memoria)
            serializer.Serialize(memoria, usuariosSalvos);

            //Escreve os bytes no arquivo
            File.WriteAllBytes("usuarios.dat", memoria.ToArray());
        }

        public List<UsuarioModel> Listar()
        {
            //Verifica se o arquivo existe
            if (!File.Exists("usuarios.dat"))
            {
                return new List<UsuarioModel>();
            }
            
            //le os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("usuarios.dat");
            
            //Desserializa
            BinaryFormatter serializer = new BinaryFormatter();

            //Passa os bytes para a MemoryStream
            MemoryStream memoria = new MemoryStream(bytesSerializer);
            return (List<UsuarioModel>) serializer.Deserialize(memoria);
        }

        public UsuarioModel Login(string email, string senha)
        {
            List<UsuarioModel> usuario = Listar();
            foreach (var user in usuario)
            {
                if (user.Email == email && user.Senha == senha)
                {
                    return user;
                }
            }
            return null;
        }
    }
}