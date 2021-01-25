using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Domains
{
    public class ParticipanteDomain
    {
        [Required]
        public string Nome { get; set; }
        public decimal Contribuicao { get; set; }
        public bool Pagou { get; set; }
    }
}
