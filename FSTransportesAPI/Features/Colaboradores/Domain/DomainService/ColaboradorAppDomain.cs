using FSTransportesAPI.Features.Colaboradores.Domain.DomainRequirements;

namespace FSTransportesAPI.Features.Colaboradores.Domain.DomainService
{
    public sealed class ColaboradorAppDomain
    {
        public string ValidarAsignacionSucursal(ColaboradorDomainRequirements requirements)
        {
            if (!requirements.EsValido())
            {
                return string.Join(" | ", requirements.ObtenerErrores());
            }

            return string.Empty;
        }
    }
}