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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model,
            [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                clienteApplicationService.Insert(model);

                //retornar status de sucesso 200 (OK)
                return Ok("Cliente cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model,
            [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                clienteApplicationService.Update(model);

                //retornar status de sucesso 200 (OK)
                return Ok("Cliente atualizado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                clienteApplicationService.Delete(id);

                //retornar status de sucesso 200 (OK)
                return Ok("Cliente excluído com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                //retornar status de sucesso 200 (OK)
                return Ok(clienteApplicationService.GetAll());
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IClienteApplicationService clienteApplicationService)
        {
            try
            {
                //retornar status de sucesso 200 (OK)
                return Ok(clienteApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }
    }
}