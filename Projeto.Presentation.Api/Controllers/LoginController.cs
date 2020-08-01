using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Presentation.Api.Authorization;

namespace Projeto.Presentation.Api.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UsuarioAutenticacaoModel model, 
            [FromServices] IUsuarioApplicationService usuarioApplicationService, 
            [FromServices] JwtConfiguration jwtConfiguration)
        {  
            try
            {
                //buscar o usuario no banco de dados pelo login e senha]
                var usuario = usuarioApplicationService.GetByLoginAndSenha(model);

                if(usuario != null) //se o usuario foi encontrado
                {
                    return Ok(jwtConfiguration.GenerateToken(usuario.Login)); 
                }
                else
                {
                    return StatusCode(403, "Usuário não encontrado.");
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}