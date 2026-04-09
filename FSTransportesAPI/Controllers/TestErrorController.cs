using Microsoft.AspNetCore.Mvc;

namespace FSTransportesAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestErrorController : ControllerBase
    {
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            throw new ArgumentException("Este es un error de argumento inválido provocado.");
        }

        [HttpGet("NotFound")]
        public IActionResult GetNotFound()
        {
            throw new KeyNotFoundException("El recurso solicitado no existe en el sistema.");
        }

        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            throw new Exception("Error crítico inesperado en el servidor.");
        }

        [HttpGet("Unauthorized")]
        public IActionResult GetUnauthorized()
        {
            throw new UnauthorizedAccessException("No tienes permisos para realizar esta acción.");
        }
    }
}