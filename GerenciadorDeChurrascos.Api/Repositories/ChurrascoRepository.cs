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
        public ChurrascoRepository(IChurrascostoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _churrasco = database.GetCollection<ChurrascoDomain>(settings.ChurrascosCollectionName);
        }

        public void Adicionar(ChurrascoDomain churrasco)
        {
            _churrasco.InsertOne(churrasco);
        }

        public void Atualizar(string id, ChurrascoDomain churrasco)
        {
            _churrasco.ReplaceOne(c => c.Id == id, churrasco);
        }

        public ChurrascoDomain BuscarporId(string id)
        {
            return _churrasco.Find<ChurrascoDomain>(c => c.Id == id).First();
        }

        public List<ChurrascoDomain> Listar()
        {
            return _churrasco.AsQueryable<ChurrascoDomain>().ToList();
        }

        public void Remover(string id)
        {
            _churrasco.DeleteOne(c => c.Id == id);
        }
        public void AdicionarParticipante(string idChurrasco, ParticipanteDomain participante)
        {
            ChurrascoDomain churrasco = BuscarporId(idChurrasco);
            if (churrasco != null)
            {
                List<ParticipanteDomain> participantesList = churrasco.Participantes.ToList();
                participantesList.Add(participante);
                churrasco.Participantes = participantesList.ToArray();
                _churrasco.ReplaceOne(c => c.Id == idChurrasco, churrasco);
            }
            else
            {
                throw new Exception("Churrasco não Existe");
            }
            
        }
        public void RemoverParticipante(string idChurrasco, int posicaoArray)
        {
            ChurrascoDomain churrasco = BuscarporId(idChurrasco);
            if (churrasco != null)
            {
                List<ParticipanteDomain> participantesList = churrasco.Participantes.ToList();
                participantesList.RemoveAt(posicaoArray);
                churrasco.Participantes = participantesList.ToArray();
                _churrasco.ReplaceOne(c => c.Id == idChurrasco, churrasco);
            }
            else
            {
                throw new Exception("Churrasco não Existe");
            }

        }
    }
}
