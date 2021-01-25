using GerenciadorDeChurrascos.Api.Contexts;
using GerenciadorDeChurrascos.Api.Domains;
using GerenciadorDeChurrascos.Api.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace GerenciadorDeChurrascos.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<UsuarioDomain> _usuario;
        public UsuarioRepository(IChurrascostoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuario = database.GetCollection<UsuarioDomain>(settings.UsuariosCollectionName);
        }

        public void Atualizar(string id, UsuarioDomain usuarioAtualizado)
        {
            _usuario.ReplaceOne(u => u.Id == id, usuarioAtualizado);
        }

        public UsuarioDomain BuscarPorId(string id)
        {
            return _usuario.Find(u => u.Id == id).First();
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            _usuario.InsertOne(novoUsuario);
        }

        public void Deletar(string id)
        {
            _usuario.DeleteOne(u => u.Id == id);
        }

        public List<UsuarioDomain> Listar()
        {
            return _usuario.AsQueryable<UsuarioDomain>().ToList();
        }

        public UsuarioDomain Login(string email, string senha)
        {
            return _usuario.Find(u => u.Email == email && u.Senha == senha).First();
        }
    }
}
