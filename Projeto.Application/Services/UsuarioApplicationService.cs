using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        //atributo
        private IUsuarioDomainService usuarioDomainService;

        //construtor para injeção de dependência
        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService)
        {
            this.usuarioDomainService = usuarioDomainService;
        }

        public void Insert(UsuarioCadastroModel model)
        {
            var usuario = new Usuario();

            usuario.Nome = model.Nome;
            usuario.Login = model.Login;
            usuario.Senha = model.Senha;
            usuario.DataCriacao = DateTime.Now;

            usuarioDomainService.Insert(usuario);
        }

        public Usuario GetByLoginAndSenha(UsuarioAutenticacaoModel model)
        {
            return usuarioDomainService
                .GetByLoginAndSenha(model.Login, model.Senha);
        }

        public Usuario GetByLogin(string login)
        {
            return usuarioDomainService.GetByLogin(login);
        }
    }
}
