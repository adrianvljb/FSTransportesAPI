using FSTransportesAPI.Features.Transportistas.Dtos;
using FSTransportesAPI.Features.Transportistas.Domain.DomainRequirements;
using FSTransportesAPI.Features.Transportistas.Domain.DomainService;
using FSTransportesAPI.Features.Transportistas.Domain.Repositories;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Common;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Threading.Tasks;

namespace FSTransportesAPI.Features.Transportistas.Services
{
    [ExcludeFromCodeCoverage]
    public class TransportistaAppService
    {
        private readonly ITransportistaRepository _repository;
        private readonly TransportistaAppDomain _domainService;

        public TransportistaAppService(ITransportistaRepository repository, TransportistaAppDomain domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<RespuestaOperacionDto> CrearTransportista(CrearTransportistaRequestDto dto)
        {
            try
            {
                bool existeNombre = await _repository.ExisteNombreAsync(dto.Nombre);
                
                var requirements = TransportistaDomainRequirements.Fill(
                    nombreYaExiste: existeNombre, 
                    tarifaPorKilometro: dto.TarifaPorKilometro
                );

                string errorDominio = _domainService.ValidarRegistro(requirements);
                if (!string.IsNullOrEmpty(errorDominio))
                    return RespuestaOperacionDto.Fallo(errorDominio);

                int nuevoId = await GuardarNuevoTransportista(dto);

                return RespuestaOperacionDto.Ok(Mensajes.REGISTRO_EXITOSO, new { IdTransportista = nuevoId });
            }
            catch (Exception)
            {
                return RespuestaOperacionDto.Fallo(Mensajes.ERROR_INESPERADO);
            }
        }

        private async Task<int> GuardarNuevoTransportista(CrearTransportistaRequestDto dto)
        {
            var nuevoTransportista = new Transportista
            {
                Nombre = dto.Nombre,
                TarifaPorKilometro = dto.TarifaPorKilometro,
                Activo = true,
                UsuarioAgrega = dto.IdUsuarioRegistro,
                FechaAgrega = DateTime.Now
            };

            return await _repository.AgregarAsync(nuevoTransportista);
        }
    }
}