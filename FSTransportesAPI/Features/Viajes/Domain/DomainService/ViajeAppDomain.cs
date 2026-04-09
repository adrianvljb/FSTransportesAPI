using FSTransportesAPI.Features.Viajes.Domain.DomainRequirements;

namespace FSTransportesAPI.Features.Viajes.Domain.DomainService
{
    public sealed class ViajeAppDomain
    {
        public string ValidarRegistroViaje(ViajeDomainRequirements requirements)
        {
            if (!requirements.EsValido())
            {
                return string.Join(" | ", requirements.ObtenerErrores());
            }

            return string.Empty;
        }
    }
}