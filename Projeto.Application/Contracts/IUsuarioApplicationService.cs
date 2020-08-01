using Projeto.Application.Models;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        void Insert(UsuarioCadastroModel model);

        Usuario GetByLogin(string login);

        Usuario GetByLoginAndSenha(UsuarioAutenticacaoModel model);
    }
}
