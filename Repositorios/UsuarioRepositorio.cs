using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Http;
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
        public UsuarioModel CadastrarAdmin()
        {
            //Dados do admin
            UsuarioModel usuario = new UsuarioModel();
            usuario.Id = 1;
            usuario.Nome = "Administrador";
            usuario.Email = "admin@carfel.com";
            usuario.Senha = "admin";
            usuario.Tipo = "admin";

            return usuario;
        }
        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            //Cadastra um admin quando o arquivo do banco de dados é criado
            UsuarioModel usuarioAdmin;
            if (usuariosSalvos.Count == 0)
            {
                usuarioAdmin = CadastrarAdmin();
                usuariosSalvos.Add(usuarioAdmin);
            }

            //Incrementa o id do usuario
            usuario.Id = usuariosSalvos.Count + 1;

            //Adiciona a lista de usuariosSalvos
            usuariosSalvos.Add(usuario);

            //Serializa a lista de usuarios
            SerializerList();

            //Retorna o usuario
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
            
            //Lê os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("usuarios.dat");
            
            //Desserializa
            BinaryFormatter serializer = new BinaryFormatter();

            //Passa os bytes para a MemoryStream
            MemoryStream memoria = new MemoryStream(bytesSerializer);
            return (List<UsuarioModel>) serializer.Deserialize(memoria);
        }

        public UsuarioModel Login(string email, string senha)
        {
            //Lê o arquivo
            List<UsuarioModel> usuarios = Listar();
            foreach (var user in usuarios)
            {
                //Verifica se email e senha digitados correspondem aos do banco de dados
                if (user.Email == email && user.Senha == senha)
                {
                    //Caso encontre retorna o usuario
                    return user;
                }
            }
            //Caso contrario retorna null
            return null;
        }

        public UsuarioModel BuscarPorUser(int id)
        {
            //Lê o arquivo
            List<UsuarioModel> usuarios = Listar();
            foreach (var user in usuarios)
            {
                //Procura por um id correspondente
                if (user.Id == id)
                {
                    //Caso encontre, retorna o usuario 
                    return user;
                }
            }
            //Caso contrario retorna null
            return null;
        }
    }
}