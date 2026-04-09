using FSTransportesAPI.Features.Sucursales.Domain.DomainRequirements;

namespace FSTransportesAPI.Features.Sucursales.Domain.DomainService
{
    public sealed class SucursalAppDomain
    {
        public string ValidarRegistro(SucursalDomainRequirements requirements)
        {
            if (!requirements.EsValido())
            {
                return string.Join(" | ", requirements.ObtenerErrores());
            }

            return string.Empty;
        }
    }
}