using aulao.orm.domain;
using aulao.orm.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aulao.orm.api.Controllers
{
    [ApiController]
    [Route("cor")]
    public class CorController : ControllerBase
    {
        private readonly ILogger<CorController> _log;
        private readonly ICorService _service;
        public CorController(ILogger<CorController> log, ICorService service)
        {
            _log = log;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                return Ok(await _service.ListarAsync());
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Deu Ruim Manolo", e.Message });
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
                return BadRequest(new { Info = "Deu Ruim Manolo", e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] Cor cor)
        {
            try
            {
                await _service.CriarAsync(cor.Nome);

                return Ok(); //200 OK
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Deu Ruim Manolo", e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Cor cor)
        {
            try
            {
                await _service.EditarAsync(cor.Id, cor.Nome);

                return Ok(); //200 OK
            }
            catch (Exception e)
            {
                return BadRequest(new { Info = "Deu Ruim Manolo", e.Message });
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
                return BadRequest(new { Info = "Deu Ruim Manolo", e.Message });
            }
        }
    }
}
