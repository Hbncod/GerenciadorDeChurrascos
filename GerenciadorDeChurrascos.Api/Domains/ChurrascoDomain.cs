using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Domains
{
    public class ChurrascoDomain
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Informacoes { get; set; }
        public decimal ValorArrecadado { get; set; }
        public DateTime Data { get; set; }
        public List<ParticipanteDomain> Participantes { get; set; }
    }
}
