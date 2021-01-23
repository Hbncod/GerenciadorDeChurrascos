using GerenciadorDeChurrascos.Api.Contexts;
using GerenciadorDeChurrascos.Api.Domains;
using GerenciadorDeChurrascos.Api.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Repositories
{
    public class ChurrascoRepository : IChurrascoRepository
    {
        private readonly IMongoCollection<ChurrascoDomain> _churrasco;
        public ChurrascoRepository(IChurrascoDatabaseSettions settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _churrasco = database.GetCollection<ChurrascoDomain>(settings.ChurrascosCollectionName);
        }

        public void Adicionar(ChurrascoDomain churrasco)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(string id, ChurrascoDomain churrasco)
        {
            throw new NotImplementedException();
        }

        public List<ChurrascoDomain> Listar()
        {
            return _churrasco.AsQueryable<ChurrascoDomain>().ToList();
        }

        public void Remover(string id)
        {
            throw new NotImplementedException();
        }
    }
}
