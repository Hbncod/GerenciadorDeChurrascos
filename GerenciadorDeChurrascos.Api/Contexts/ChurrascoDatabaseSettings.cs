using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Contexts
{
    public class ChurrascoDatabaseSettions : IChurrascoDatabaseSettions
    {
        public string UsuariosCollectionName { get; set; }
        public string ChurrascosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IChurrascoDatabaseSettions
    {
        string UsuariosCollectionName { get; set; }
        string ChurrascosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
