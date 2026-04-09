using Microsoft.AspNetCore.Mvc;
using FSTransportesAPI.Features.Viajes.Dtos;
using FSTransportesAPI.Features.Viajes.Services;

namespace FSTransportesAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeAppService _viajeAppService;

    public ViajeController(IViajeAppService viajeAppService)
    {
    _viajeAppService = viajeAppService;
    }

        [HttpPost("RegistrarViaje")]
        public async Task<IActionResult> RegistrarViaje([FromBody] RegistrarViajeRequestDto dto)
        {
            // El servicio nos devuelve el objeto estandarizado
            var resultado = await _viajeAppService.RegistrarViaje(dto);

            if (resultado.Exito)
            {
                
                return Ok(resultado);
            }

            // Si Exito es false, devolvemos un HTTP 400 con el error
            return BadRequest(resultado);
        }
    }
}