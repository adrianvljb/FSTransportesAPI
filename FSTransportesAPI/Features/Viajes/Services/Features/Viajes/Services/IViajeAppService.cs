using FSTransportesAPI.Features.Viajes.Dtos;
using FSTransportesAPI.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FSTransportesAPI.Features.Viajes.Services
{
    public interface IViajeAppService
    {
        Task<RespuestaOperacionDto> RegistrarViaje(RegistrarViajeRequestDto dto);
    }
}