using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
        public decimal ValorIndicadoSemBebida { get; set; }
        public decimal ValorIndicadoComBebida { get; set; }
        public decimal ValorArrecadado { get; set; }
        public DateTime Data { get; set; }
        public ParticipanteDomain[] Participantes { get; set; }
    }
    
}
