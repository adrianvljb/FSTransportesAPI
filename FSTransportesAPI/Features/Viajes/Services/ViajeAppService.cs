using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Features.Viajes.Dtos;
using FSTransportesAPI.Features.Viajes.Domain.DomainRequirements;
using FSTransportesAPI.Features.Viajes.Domain.DomainService;
using FSTransportesAPI.Features.Viajes.Domain.Repositories;
using FSTransportesAPI.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FSTransportesAPI.Features.Viajes.Services
{
    [ExcludeFromCodeCoverage]
    public class ViajeAppService : IViajeAppService
    {
        private readonly IViajeRepository _repository;
        private readonly ViajeAppDomain _domainService;

        public ViajeAppService(IViajeRepository repository, ViajeAppDomain domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<RespuestaOperacionDto> RegistrarViaje(RegistrarViajeRequestDto dto)
        {
            try
            {
                string errorDominio = await ValidarReglasDeNegocio(dto);
                if (!string.IsNullOrEmpty(errorDominio)) 
                    return RespuestaOperacionDto.Fallo(errorDominio);

                string errorDuplicidad = await ValidarNoColaboradoresConViajeEnFecha(dto);
                if (!string.IsNullOrEmpty(errorDuplicidad)) 
                    return RespuestaOperacionDto.Fallo(errorDuplicidad);

                // Centralización de fecha para consistencia de auditoría
                DateTime fechaRegistro = DateTime.Now;
                var nuevoViaje = MapearDtoAEntidad(dto, fechaRegistro);

                int nuevoIdViaje = await _repository.AgregarViajeAsync(nuevoViaje);

                return RespuestaOperacionDto.Ok(Mensajes.REGISTRO_EXITOSO, new { IdViaje = nuevoIdViaje });
            }
            catch (Exception)
            {
                return RespuestaOperacionDto.Fallo(Mensajes.ERROR_INESPERADO);
            }
        }

        private async Task<string> ValidarReglasDeNegocio(RegistrarViajeRequestDto dto)
        {
            var usuario = await _repository.ObtenerUsuarioPorIdAsync(dto.IdUsuarioRegistro);
            decimal distanciaTotal = dto.Detalles!.Sum(d => d.DistanciaKilometros);

            var requirements = ViajeDomainRequirements.Fill(
                existeUsuario: usuario != null,
                usuarioActivo: usuario?.Activo ?? false,
                esGerente: usuario?.IdRol == 1,
                distanciaTotal: distanciaTotal
            );

            return _domainService.ValidarRegistroViaje(requirements);
        }

        private async Task<string> ValidarNoColaboradoresConViajeEnFecha(RegistrarViajeRequestDto dto)
        {
            foreach (var detalle in dto.Detalles!)
            {
                bool yaViajoHoy = await _repository.ExisteViajeColaboradorEnFechaAsync(detalle.IdColaborador, dto.FechaViaje);
                if (yaViajoHoy) return Mensajes.ERROR_COLABORADOR_YA_VIAJO_HOY;
            }
            return string.Empty;
        }

        private Viaje MapearDtoAEntidad(RegistrarViajeRequestDto dto, DateTime fechaRegistro)
        {
            return new Viaje
            {
                FechaViaje = dto.FechaViaje,
                IdSucursal = dto.IdSucursal,
                IdTransportista = dto.IdTransportista,
                IdUsuarioRegistro = dto.IdUsuarioRegistro,
                UsuarioAgrega = dto.IdUsuarioRegistro,
                FechaAgrega = fechaRegistro,
                Detalles = dto.Detalles!.Select(d => new ViajeDetalle
                {
                    IdColaborador = d.IdColaborador,
                    DistanciaKilometros = d.DistanciaKilometros,
                    TarifaSugerida = d.TarifaSugerida,
                    UsuarioAgrega = dto.IdUsuarioRegistro,
                    FechaAgrega = fechaRegistro
                }).ToList()
            };
        }
    }
}