using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Transportistas.Dtos
{
    [ExcludeFromCodeCoverage]
    public class CrearTransportistaRequestDto
    {
        public string Nombre { get; set; } = string.Empty;
        
        public decimal TarifaPorKilometro { get; set; }
        
        
        public int IdUsuarioRegistro { get; set; } 
    }
}