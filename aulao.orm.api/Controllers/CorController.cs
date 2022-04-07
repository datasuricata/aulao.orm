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
    }
}
