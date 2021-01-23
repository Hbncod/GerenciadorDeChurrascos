using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
