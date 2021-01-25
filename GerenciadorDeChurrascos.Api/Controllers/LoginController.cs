using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GerenciadorDeChurrascos.Api.Domains;
using GerenciadorDeChurrascos.Api.Interfaces;
using GerenciadorDeChurrascos.Api.NovaPasta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDeChurrascos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        public LoginController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Token do usuário</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _repository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound();
                }


                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id)

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Churrasco-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "ChurrascoApi",
                    audience: "ChurrascoApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}
