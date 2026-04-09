using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Common; 

namespace FSTransportesAPI.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // El log interno SIEMPRE guarda el error real (SQL, NullReference, etc.).
                _logger.LogError(ex, "Ocurrió un error no controlado: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
           
            var (statusCode, title, detail) = exception switch
            {
                ArgumentException => (StatusCodes.Status400BadRequest, MensajesSistema.TITULO_BAD_REQUEST, MensajesSistema.DETALLE_BAD_REQUEST),
                KeyNotFoundException => (StatusCodes.Status404NotFound, MensajesSistema.TITULO_NOT_FOUND, MensajesSistema.DETALLE_NOT_FOUND),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, MensajesSistema.TITULO_UNAUTHORIZED, MensajesSistema.DETALLE_UNAUTHORIZED),

                // (Errores de SQL) -> Ocultamos el ex.Message
                DbUpdateException => (StatusCodes.Status409Conflict, MensajesSistema.TITULO_CONFLICTO, MensajesSistema.DETALLE_CONFLICTO_BD),

                // Cualquier otro error de código (NullReference, División por cero, etc.)
                _ => (StatusCodes.Status500InternalServerError, MensajesSistema.TITULO_ERROR_INTERNO, MensajesSistema.DETALLE_ERROR_INTERNO)
            };

            var response = new
            {
                status = statusCode,
                title = title,
                detail = detail,
                traceId = context.TraceIdentifier
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}