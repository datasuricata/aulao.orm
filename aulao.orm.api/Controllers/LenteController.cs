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
    [Route("lente")]
    public class LenteController : ControllerBase
    {
        private readonly ILogger<LenteController> _log;
        private readonly ILenteService _service;

        public LenteController(ILogger<LenteController> log, ILenteService service)
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
        public async Task<IActionResult> CriarAsync([FromBody] Lente lente)
        {
            try
            {
                await _service.CriarAsync(lente);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Não funcionou", e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Lente lente)
        {
            try
            {
                await _service.EditarAsync(lente.Id, lente);

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
