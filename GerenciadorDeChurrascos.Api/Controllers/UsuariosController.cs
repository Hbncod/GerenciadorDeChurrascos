using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeChurrascos.Api.Domains;
using GerenciadorDeChurrascos.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeChurrascos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        [HttpGet]
        public IActionResult Get()
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
        /// Busca um usuário pelo seu id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(string id)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _repository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }

                return NotFound($"O usuário {id} não pode ser encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        [HttpPost]
        public IActionResult Cadastro(UsuarioDomain novoUsuario)
        {
            try
            {
                _repository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Atualiza um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuarioAtualizado">Dados atualizados do usuário</param>
        [HttpPut("{id}")]
        public IActionResult Patch(string id, UsuarioDomain usuarioAtualizado)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _repository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    _repository.Atualizar(id, usuarioAtualizado);

                    return StatusCode(204);
                }

                return NotFound($"O usuário {id} não foi encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _repository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    _repository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound($"O usuário {id} não foi encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
