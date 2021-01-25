using GerenciadorDeChurrascos.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Interfaces
{
    public interface IChurrascoRepository
    {
        /// <summary>
        /// Lista todos os 
        /// </summary>
        /// <returns></returns>
        List<ChurrascoDomain> Listar();
        void Adicionar(ChurrascoDomain churrasco);
        void Atualizar(string id, ChurrascoDomain churrasco);
        void Remover(string id);
        ChurrascoDomain BuscarporId(string id);
        void AdicionarParticipante(string idChurrasco,ParticipanteDomain participante);
        void RemoverParticipante(string idChurrasco,int posicaoArray);
        void AtualizaValorArrecadado(ChurrascoDomain churrascoDomain);
    }
}