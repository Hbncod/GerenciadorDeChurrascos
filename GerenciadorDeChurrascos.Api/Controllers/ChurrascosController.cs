using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeChurrascos.Api.Domains;
using GerenciadorDeChurrascos.Api.Interfaces;
using GerenciadorDeChurrascos.Api.Repositories;
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
