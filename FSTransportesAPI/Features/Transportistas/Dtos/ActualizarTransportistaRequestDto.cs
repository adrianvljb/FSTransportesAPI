using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Transportistas.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ActualizarTransportistaRequestDto
    {
        // Aquí SÍ pedimos el ID para saber a quién vamos a modificar
        public int IdTransportista { get; set; }
        
        public string Nombre { get; set; } = string.Empty;
        
        public decimal TarifaPorKilometro { get; set; }
        
        public bool Activo { get; set; }
        
        // Para tu campo 'UsuarioModifica'
        public int IdUsuarioModifica { get; set; }
    }
}