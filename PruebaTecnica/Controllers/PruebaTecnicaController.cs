using Application.Recaudos;
using Application.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PruebaTecnicaController : ControllerBase
    {

        private readonly ILogger<PruebaTecnicaController> _logger;
        private readonly IRecaudos _recaudos;

        public PruebaTecnicaController(ILogger<PruebaTecnicaController> logger, IRecaudos recaudos)
        {
            _logger = logger;
            _recaudos = recaudos;
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<List<Recaudo>>> Login([FromRoute] string date)
        {
          return await _recaudos.GetRecaudos(date);
        }

        [HttpGet("Report/{date}")]
        public async Task<ActionResult<List<RecaudoAgrupadoDTO>>> GetReport([FromQuery] string date)
        {
            return await _recaudos.GetReport(date);
        }
    }
}