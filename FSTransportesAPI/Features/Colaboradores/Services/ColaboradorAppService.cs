using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Features.Colaboradores.Dtos;
using FSTransportesAPI.Features.Colaboradores.Domain.DomainRequirements;
using FSTransportesAPI.Features.Colaboradores.Domain.DomainService;
using FSTransportesAPI.Common;
using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Colaboradores.Services
{
    [ExcludeFromCodeCoverage]
    public partial class ColaboradorAppService
    {
        private readonly FSTransportesDbContext _context;
        private readonly ColaboradorAppDomain _domainService;

        public ColaboradorAppService(
            FSTransportesDbContext context,
            ColaboradorAppDomain domainService)
        {
            _context = context;
            _domainService = domainService;
        }

        public async Task<string> AsignarSucursal(AsignarSucursalRequestDto dto)
        {
            try
            {
                
                bool existeColaborador = await _context.Colaboradores
                    .AnyAsync(c => c.IdColaborador == dto.IdColaborador);

                bool existeSucursal = await _context.Sucursales
                    .AnyAsync(s => s.IdSucursal == dto.IdSucursal);

                bool existeAsignacion = await _context.ColaboradoresSucursales
                    .AnyAsync(cs => cs.IdColaborador == dto.IdColaborador
                                 && cs.IdSucursal == dto.IdSucursal);

               
                var requirements = ColaboradorDomainRequirements.Fill(
                    existeColaborador: existeColaborador,
                    existeSucursal: existeSucursal,
                    yaAsignado: existeAsignacion,
                    distancia: dto.DistanciaKilometros
                );

                
                string errores = _domainService.ValidarAsignacionSucursal(requirements);
                if (!string.IsNullOrEmpty(errores)) return errores;

                
                var asignacion = new ColaboradorSucursal
                {
                    IdColaborador = dto.IdColaborador,
                    IdSucursal = dto.IdSucursal,
                    DistanciaKilometros = dto.DistanciaKilometros,
                    UsuarioAgrega = dto.IdUsuarioRegistro, 
                    FechaAgrega = DateTime.Now
                };

                _context.ColaboradoresSucursales.Add(asignacion);
                await _context.SaveChangesAsync();

                return Mensajes.REGISTRO_EXITOSO;
            }
            catch (Exception)
            {
                return Mensajes.ERROR_INESPERADO;
            }
        }
    }
}