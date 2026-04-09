using Microsoft.AspNetCore.Mvc;
using FSTransportesAPI.Features.Viajes.Services;
using System;
using System.Threading.Tasks;

namespace FSTransportesAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        // 1. Uso del nombre correcto del servicio
        private readonly ReporteViajeAppService _reporteAppService;

        public ReporteController(ReporteViajeAppService reporteAppService)
        {
            _reporteAppService = reporteAppService;
        }

        [HttpGet("ResumenViajes")]
        public async Task<IActionResult> GetResumen([FromQuery] DateTime inicio, [FromQuery] DateTime fin)
        {
            // Validación básica de fechas en el controlador
            if (inicio > fin)
            {
                return BadRequest(new { error = "La fecha de inicio no puede ser mayor a la fecha de fin." });
            }

            // 2. Uso correcto de la variable declarada
            var datos = await _reporteAppService.ObtenerResumenViajes(inicio, fin);

            return Ok(datos);
        }
    }
}