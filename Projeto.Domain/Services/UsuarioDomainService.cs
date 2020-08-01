using Projeto.Domain.Contracts.CrossCutting;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<Usuario>, IUsuarioDomainService
    {
        //atributos
        private IUsuarioRepository usuarioRepository;
        private IMD5Cryptography cryptography;

        //construtor para injeção de dependência (inicialização)
        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IMD5Cryptography cryptography)
            : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.cryptography = cryptography;
        }

        public override void Insert(Usuario obj)
        {
            //verificar se o login informado não está cadastrado no banco
            if(usuarioRepository.GetByLogin(obj.Login) == null)
            {
                //criptografar a senha do usuário
                obj.Senha = cryptography.Encrypt(obj.Senha);

                //gravar no banco de dados
                usuarioRepository.Insert(obj);
            }
            else
            {
                throw new Exception("Erro. O login informado já encontra-se cadastrado.");
            }
        }

        public override void Update(Usuario obj)
        {
            //buscar o usuario no banco de dados pelo id
            var registro = usuarioRepository.GetById(obj.Id);

            //verificando se o usuario foi encontrado
            if(registro != null)
            {
                registro.Nome = obj.Nome;
                registro.Senha = cryptography.Encrypt(obj.Senha);

                usuarioRepository.Update(registro);
            }
            else
            {
                throw new Exception("Erro. Usuário não foi encontrado.");
            }
        }

        public Usuario GetByLoginAndSenha(string login, string senha)
        {
            var registro = usuarioRepository
                .GetByLoginAndSenha(login, cryptography.Encrypt(senha));

            //verificar se o usuario foi encontrado
            if(registro != null)
            {
                return registro;
            }
            else
            {
                throw new Exception("Usuário não foi encontrado.");
            }
        }

        public Usuario GetByLogin(string login)
        {
            return usuarioRepository.GetByLogin(login);
        }
    }
}
