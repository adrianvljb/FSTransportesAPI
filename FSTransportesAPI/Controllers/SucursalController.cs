using Microsoft.AspNetCore.Mvc;
using FSTransportesAPI.Common;
using FSTransportesAPI.Features.Sucursales.Services;
using FSTransportesAPI.Features.Sucursales.Dtos;

namespace FSTransportesAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly SucursalAppService _sucursalAppService;

        public SucursalController(SucursalAppService sucursalAppService)
        {
            _sucursalAppService = sucursalAppService;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ObtenerSucursales()
        {
            var sucursales = await _sucursalAppService.ObtenerSucursales();
            return Ok(sucursales);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarSucursal([FromBody] RegistrarSucursalRequestDto dto)
        {
            var resultado = await _sucursalAppService.RegistrarSucursal(dto);

            if (resultado == Mensajes.REGISTRO_EXITOSO)
            {
                return Ok(new { mensaje = resultado });
            }

            return BadRequest(new { error = resultado });
        }
    }
}