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
using Projeto.Domain.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PlanoCadastroModel model, 
            [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                planoApplicationService.Insert(model);

                //retornar status de sucesso 200 (OK)
                return Ok("Plano cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(PlanoEdicaoModel model,
            [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                planoApplicationService.Update(model);

                //retornar status de sucesso 200 (OK)
                return Ok("Plano atualizado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                planoApplicationService.Delete(id);

                //retornar status de sucesso 200 (OK)
                return Ok("Plano excluído com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                //retornar status de sucesso 200 (OK)
                return Ok(planoApplicationService.GetAll());
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IPlanoApplicationService planoApplicationService)
        {
            try
            {
                //retornar status de sucesso 200 (OK)
                return Ok(planoApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }
    }
}