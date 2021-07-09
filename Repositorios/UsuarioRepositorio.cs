using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using CheckPoint.Interfaces;
using CheckPoint.Models;
using CheckPoint.Util;

namespace CheckPoint.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        public List<UsuarioModel> _usuarios;

        public UsuarioRepositorio()
        {
            if (File.Exists("FileData/usuarios.dat"))
                _usuarios = Listar();
            else
                _usuarios = new List<UsuarioModel>();
        }

        public UsuarioModel CadastrarAdmin()
        {
            HashUtil hashUtil = new HashUtil();
            string senhaHash = hashUtil.CriptografarSenha("admin");

            UsuarioModel usuario = new UsuarioModel(1, "Administrador", "admin@carfel.com", senhaHash, "admin");

            return usuario;
        }

        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            UsuarioModel usuarioAdmin;
            
            if (_usuarios.Count == 0)
            {
                usuarioAdmin = CadastrarAdmin();
                _usuarios.Add(usuarioAdmin);
            }

            usuario.Id = _usuarios.Count + 1;
            _usuarios.Add(usuario);

            SerializerList();

            return usuario;
        }

        private void SerializerList()
        {
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(memoria, _usuarios);

            File.WriteAllBytes("FileData/usuarios.dat", memoria.ToArray());
        }

        public List<UsuarioModel> Listar()
        {
            if (!File.Exists("FileData/usuarios.dat"))
                return new List<UsuarioModel>();
            
            byte[] bytesSerializer = File.ReadAllBytes("FileData/usuarios.dat");
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memoria = new MemoryStream(bytesSerializer);

            return (List<UsuarioModel>) serializer.Deserialize(memoria);
        }

        public UsuarioModel Login(string email, string senha)
        {
            HashUtil hashUtil = new HashUtil();
            UsuarioModel usuario = _usuarios.FirstOrDefault(x => x.Email == email);

            if (usuario == null)
                return null;

            bool senhaValida = hashUtil.VerificarSenha(senha, usuario.Senha);

            if (senhaValida)
                return usuario;

            return null;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}