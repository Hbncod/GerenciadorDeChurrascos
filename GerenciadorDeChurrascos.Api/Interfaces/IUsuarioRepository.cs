using GerenciadorDeChurrascos.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeChurrascos.Api.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista os usuários
        /// </summary>
        /// <returns>Uma lista de usuario</returns>
        List<UsuarioDomain> Listar();
        /// <summary>
        /// Lista um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario a ser buscado</param>
        /// <returns>O usuário do id informado</returns>
        UsuarioDomain BuscarPorId(string id);
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Dados do usuário a ser cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);
        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuarioAtualizado">dados do usuário atualizado</param>
        void Atualizar(string id, UsuarioDomain usuarioAtualizado);
        /// <summary>
        /// Deleta um usuário pel seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        void Deletar(string id);
        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="email">email para ser comparado ao realizar o login</param>
        /// <param name="senha">senha a ser comparada ao realizar o login</param>
        /// <returns></returns>
        UsuarioDomain Login(string email, string senha);

    }
}
