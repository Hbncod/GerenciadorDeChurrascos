using GerenciadorDeChurrascos.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Interfaces
{
    public interface IChurrascoRepository
    {
        List<ChurrascoDomain> Listar();
        void Adicionar(ChurrascoDomain churrasco);
        void Atualizar(string id, ChurrascoDomain churrasco);
        void Remover(string id);
    }
}