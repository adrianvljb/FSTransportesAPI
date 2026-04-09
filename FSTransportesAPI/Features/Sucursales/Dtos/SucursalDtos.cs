using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Sucursales.Dtos
{
    [ExcludeFromCodeCoverage]
    public class RegistrarSucursalRequestDto
    {
       public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty; 

        public int IdUsuarioRegistro { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SucursalResponseDto
    {
        public int IdSucursal { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Ubicacion { get; set; }  = string.Empty;

        public bool Activo { get; set; }
    }
}