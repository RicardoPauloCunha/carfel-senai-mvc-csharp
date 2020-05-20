using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Projeto_CarFel_CheckPoint_Web.Interfaces;
using Projeto_CarFel_CheckPoint_Web.Models;
using Projeto_CarFel_CheckPoint_Web.Util;

namespace Projeto_CarFel_CheckPoint_Web.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        public List<UsuarioModel> _usuarios;

        public UsuarioRepositorio()
        {
            // Verifica se o arquivo existe
            if (File.Exists("filedata/usuarios.dat"))
            {
                // Lista os usuarios
                _usuarios = Listar();
            }
            else
            {
                // Declara uma nova lista
                _usuarios = new List<UsuarioModel>();
            }
        }

        public UsuarioModel CadastrarAdmin()
        {
            //Senha Criptografada
            HashUtil hashUtil = new HashUtil();

            // Faz o hash da senha
            string senhaHash = hashUtil.CriptografarSenha("admin");

            //Dados do admin
            UsuarioModel usuario = new UsuarioModel(1, "Administrador", "admin@carfel.com", senhaHash, "admin");

            // Cadastra o admin
            return usuario;
        }

        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            // Declara a variavel do usuário admin
            UsuarioModel usuarioAdmin;
            
            // Cadastra um admin quando o arquivo do banco de dados é criado
            if (_usuarios.Count == 0)
            {
                // Cria o usuário
                usuarioAdmin = CadastrarAdmin();
                
                // Adiciona na lista
                _usuarios.Add(usuarioAdmin);
            }

            // Incrementa o id do usuario
            usuario.Id = _usuarios.Count + 1;

            //Adiciona a lista de usuariosSalvos
            _usuarios.Add(usuario);

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
            serializer.Serialize(memoria, _usuarios);

            //Escreve os bytes no arquivo
            File.WriteAllBytes("filedata/usuarios.dat", memoria.ToArray());
        }

        public List<UsuarioModel> Listar()
        {
            //Verifica se o arquivo existe
            if (!File.Exists("filedata/usuarios.dat"))
            {
                return new List<UsuarioModel>();
            }
            
            //Lê os bytes do arquivo existente
            byte[] bytesSerializer = File.ReadAllBytes("filedata/usuarios.dat");
            
            //Desserializa
            BinaryFormatter serializer = new BinaryFormatter();

            //Passa os bytes para a MemoryStream
            MemoryStream memoria = new MemoryStream(bytesSerializer);

            // Retorna a lista de usuário
            return (List<UsuarioModel>) serializer.Deserialize(memoria);
        }

        public UsuarioModel Login(string email, string senha)
        {
            // Cria os objetos para hashar a senha
            HashUtil hashUtil = new HashUtil();

            // Busca o usuário com esse email
            UsuarioModel usuario = _usuarios.FirstOrDefault(x => x.Email == email);

            // Caso não achei nenhum usuário
            if (usuario == null) return null;

            // Verifica se a senha é igual
            bool senhaEhValida = hashUtil.VerificarSenha(senha, usuario.Senha);

            // Verifica se a senha é válida
            if (senhaEhValida)
            {
                // Retorna o usuario
                return usuario;
            }

            //Caso contrario retorna null
            return null;
        }

        public UsuarioModel BuscarPorUser(int id)
        {
            // Busca o usuário por id
            return _usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}