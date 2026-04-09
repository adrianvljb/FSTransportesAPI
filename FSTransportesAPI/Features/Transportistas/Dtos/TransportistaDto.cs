using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Transportistas.Dtos
{
    [ExcludeFromCodeCoverage]
    public class TransportistaDto
    {
        public int IdTransportista { get; set; }
        
        // Mantenemos la buena práctica del string.Empty
        public string Nombre { get; set; } = string.Empty;
        
        public decimal TarifaPorKilometro { get; set; }
        
        public bool Activo { get; set; }
    }
}