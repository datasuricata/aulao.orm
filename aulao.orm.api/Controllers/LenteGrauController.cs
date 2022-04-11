using aulao.orm.domain.Interfaces;
using aulao.orm.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aulao.orm.api.Controllers
{
    [ApiController]
    [Route("Lente")]
    public class LenteGrauController : ControllerBase
    {
        private readonly ILogger<LenteGrauController> _log;
        private readonly ILenteGrauService _service;

        public LenteGrauController(ILogger<LenteGrauController> log, ILenteGrauService service)
        {
            _log = log;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> ListaAsync()
        {
            try
            {
                return Ok(await _service.ListarAsync());

            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Não funcionou", e.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> PorIdAsync(Guid id)
        {
            try
            {
                return Ok(await _service.PorIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Não funcionou", e.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] string direita, string esquerda)
        {
            try
            {
                await _service.CriarAsync(esquerda,direita);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Não funcionou", e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]Guid id, string direita, string esquerda)
        {
            try
            {
                await _service.EditarAsync(id,esquerda,direita);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "não funcionou", e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _service.ExcluirAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "não funcionou", e.Message });
            }
        }

    }
}
