using FSTransportesAPI.Common;
using FSTransportesAPI.Features.Transportistas.Domain.DomainRequirements;

namespace FSTransportesAPI.Features.Transportistas.Domain.DomainService
{
    public class TransportistaAppDomain
    {
        public string ValidarRegistro(TransportistaDomainRequirements req)
        {
            if (req.NombreYaExiste) 
                return Mensajes.ERROR_TRANSPORTISTA_NOMBRE_DUPLICADO;
            
            if (req.TarifaPorKilometro <= 0) 
                return Mensajes.ERROR_TRANSPORTISTA_TARIFA_INVALIDA;

            return string.Empty;
        }
    }
}