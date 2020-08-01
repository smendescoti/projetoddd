using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model,
            [FromServices] IUsuarioApplicationService usuarioApplicationService)
        {
            try
            {
                usuarioApplicationService.Insert(model);
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromServices] IUsuarioApplicationService usuarioApplicationService)
        {
            try
            {
                //capturar o login do usuário armazenado no token JWT
                var login = User.Identity.Name;

                //acessar a camada de aplicação e obter o usuario pelo login..
                var usuario = usuarioApplicationService.GetByLogin(login);

                //retornando os dados do usuário
                return Ok(usuario);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}