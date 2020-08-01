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
    public class DependenteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(DependenteCadastroModel model,
            [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                dependenteApplicationService.Insert(model);

                //retornar status de sucesso 200 (OK)
                return Ok("Dependente cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(DependenteEdicaoModel model,
            [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                dependenteApplicationService.Update(model);

                //retornar status de sucesso 200 (OK)
                return Ok("Dependente atualizado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                dependenteApplicationService.Delete(id);

                //retornar status de sucesso 200 (OK)
                return Ok("Dependente excluído com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                //retornar status de sucesso 200 (OK)
                return Ok(dependenteApplicationService.GetAll());
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IDependenteApplicationService dependenteApplicationService)
        {
            try
            {
                //retornar status de sucesso 200 (OK)
                return Ok(dependenteApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }
    }
}