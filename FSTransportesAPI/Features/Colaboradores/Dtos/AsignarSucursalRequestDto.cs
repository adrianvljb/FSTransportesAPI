using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Colaboradores.Dtos
{
    [ExcludeFromCodeCoverage]
    public class AsignarSucursalRequestDto
    {
        public int IdColaborador { get; set; }

        public int IdSucursal { get; set; }

        public decimal DistanciaKilometros { get; set; }

        public int IdUsuarioRegistro { get; set; } 
    }
}