using Microsoft.AspNetCore.Mvc;
using FSTransportesAPI.Common;
using FSTransportesAPI.Features.Colaboradores.Services; 
using FSTransportesAPI.Features.Colaboradores.Dtos;      

namespace FSTransportesAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorAppService _colaboradorAppService;

        // Inyectamos el nuevo orquestador (AppService)
        public ColaboradorController(ColaboradorAppService colaboradorAppService)
        {
            _colaboradorAppService = colaboradorAppService;
        }

        [HttpPost("AsignarSucursal")]
        public async Task<IActionResult> AsignarSucursal([FromBody] AsignarSucursalRequestDto dto)
        {
            var resultado = await _colaboradorAppService.AsignarSucursal(dto);

            if (resultado == Mensajes.REGISTRO_EXITOSO)
            {
                return Ok(new { mensaje = resultado });
            }

            
            return BadRequest(new { error = resultado });
        }
    }
}