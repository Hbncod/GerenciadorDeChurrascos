using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeChurrascos.Api.Domains;
using GerenciadorDeChurrascos.Api.Interfaces;
using GerenciadorDeChurrascos.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeChurrascos.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrascosController : ControllerBase
    {
        private readonly IChurrascoRepository _repository;
        public ChurrascosController(IChurrascoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Listar churrascos
        /// </summary>
        /// <returns>Uma lista com todos os churrascos cadastrados</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_repository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Buscar churrasco por id
        /// </summary>
        /// <param name="id">id do churrasco a ser buscado</param>
        /// <returns>O churrasco referente ao id informado</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(string id)
        {
            try
            {
                return Ok(_repository.BuscarporId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Adicionar um novo churrasco
        /// </summary>
        /// <param name="churrasco">Churrasco a ser cadastrado</param>
        /// <returns>status code created</returns>
        [Authorize]    
        [HttpPost]
        public IActionResult AdicionarChurrasco(ChurrascoDomain churrasco)
        {
            try
            {
                _repository.Adicionar(churrasco);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Atualizar churrasco
        /// </summary>
        /// <param name="id">Id do churrasco a ser atualizado</param>
        /// <param name="novosDados">novos dados</param>
        /// <returns>status code nocontent</returns>
        [Authorize]  
        [HttpPut("{id}")]
        public IActionResult AtualizarChurrasco(string id, ChurrascoDomain novosDados)
        {
            try
            {
                novosDados.Id = id;
                _repository.Atualizar(id, novosDados);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Deletar churrasco
        /// </summary>
        /// <param name="idChurrasco">id do churrasco a ser deletado</param>
        /// <returns>status code nocontent</returns>
        [Authorize]
        [HttpDelete("{idChurrasco}")]
        public IActionResult DeletarChurrasco(string idChurrasco)
        {
            try
            {
                _repository.Remover(idChurrasco);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Adicionar participante
        /// </summary>
        /// <param name="idChurrasco">id do churrasco em que vai adicionar o participante</param>
        /// <param name="participante">Dados do participante a ser adicionado</param>
        /// <returns>status code created</returns>
        [Authorize]
        [HttpPost("{idChurrasco}")]
        public IActionResult AdicionarParticipante(string idChurrasco, ParticipanteDomain participante)
        {
            try
            {
                _repository.AdicionarParticipante(idChurrasco, participante);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Remover um participante
        /// </summary>
        /// <param name="idChurrasco">Id do churrasco em que se vai remover o participante</param>
        /// <param name="pocicaoArray">Posição no array do participante a ser excluido</param>
        /// <returns>status code no content</returns>
        [Authorize]
        [HttpDelete("{idChurrasco}/{pocicaoArray}")]
        public IActionResult RemoverParticipante(string idChurrasco, int pocicaoArray)
        {
            try
            {
                _repository.RemoverParticipante(idChurrasco, pocicaoArray);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
