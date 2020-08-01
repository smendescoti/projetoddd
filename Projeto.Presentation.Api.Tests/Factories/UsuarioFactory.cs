using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api.Tests.Factories
{
    public class UsuarioFactory
    {
        //método para retornar um objeto UsuarioCadastroModel
        public static UsuarioCadastroModel CreateUsuario
        {
            get {

                var random = new Random();
                var login = "user" + random.Next(999999);

                var model = new UsuarioCadastroModel
                {
                    Nome = "User Test",
                    Login = login,
                    Senha = "adminadmin",
                    SenhaConfirmacao = "adminadmin"
                };

                return model;
            }
        }

        //método para retornar um objeto UsuarioCadastroModel vazio
        public static UsuarioCadastroModel CreateUsuarioEmpty 
        {
            get {

                var model = new UsuarioCadastroModel
                {
                    Nome = string.Empty,
                    Login = string.Empty,
                    Senha = string.Empty,
                    SenhaConfirmacao = string.Empty
                };

                return model;
            }
        }

    }
}
