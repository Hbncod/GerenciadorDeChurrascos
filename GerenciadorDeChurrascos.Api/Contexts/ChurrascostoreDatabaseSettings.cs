using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Contexts
{
    public class ChurrascostoreDatabaseSettings : IChurrascostoreDatabaseSettings
    {
        public string UsuariosCollectionName { get; set; }
        public string ChurrascosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IChurrascostoreDatabaseSettings
    {
        string UsuariosCollectionName { get; set; }
        string ChurrascosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
