using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aulao.orm.api.Controllers
{
    [ApiController]
    [Route("lente/caracteristica")]
    public class LenteCaracteristicaController : ControllerBase
    {
        private readonly ILogger<LenteCaracteristicaController> _log;
        private readonly ILenteCaracteristicaService _service;

        public LenteCaracteristicaController(ILogger<LenteCaracteristicaController> log, ILenteCaracteristicaService service)
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
        public async Task<IActionResult> CriarAsync([FromBody] LenteCaracteristica lenteCaracteristica)
        {
            try
            {
                await _service.CriarAsync(lenteCaracteristica.Caracteristica);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Não funcionou", e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] LenteCaracteristica lenteCaracteristica)
        {
            try
            {
                await _service.EditarAsync(lenteCaracteristica.Id, lenteCaracteristica.Caracteristica);

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
