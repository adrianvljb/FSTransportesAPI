using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Features.Sucursales.Dtos;
using FSTransportesAPI.Features.Sucursales.Domain.DomainRequirements;
using FSTransportesAPI.Features.Sucursales.Domain.DomainService;
using FSTransportesAPI.Common;
using System.Diagnostics.CodeAnalysis;

namespace FSTransportesAPI.Features.Sucursales.Services
{
    [ExcludeFromCodeCoverage]
    public partial class SucursalAppService
    {
        private readonly FSTransportesDbContext _context;
        private readonly SucursalAppDomain _domainService;

        public SucursalAppService(FSTransportesDbContext context, SucursalAppDomain domainService)
        {
            _context = context;
            _domainService = domainService;
        }

        public async Task<List<SucursalResponseDto>> ObtenerSucursales()
        {
            return await _context.Sucursales
                .AsNoTracking()
                .Select(s => new SucursalResponseDto
                {
                    IdSucursal = s.IdSucursal,
                    Nombre = s.Nombre,
                    Ubicacion = s.Ubicacion, // Ajustado
                    Activo = s.Activo
                }).ToListAsync();
        }

        public async Task<string> RegistrarSucursal(RegistrarSucursalRequestDto dto)
        {
            try
            {
                bool existeNombre = await _context.Sucursales
                    .AnyAsync(s => s.Nombre.ToLower() == dto.Nombre.Trim().ToLower());

                // Ahora enviamos la ubicación al Fill
                var requirements = SucursalDomainRequirements.Fill(dto.Nombre, dto.Ubicacion, existeNombre);

                string errores = _domainService.ValidarRegistro(requirements);
                if (!string.IsNullOrEmpty(errores)) return errores;

                var nuevaSucursal = new Sucursal
                {
                    Nombre = dto.Nombre.Trim(),
                    Ubicacion = dto.Ubicacion.Trim(),
                    Activo = true,
                    UsuarioAgrega = dto.IdUsuarioRegistro,
                    FechaAgrega = DateTime.Now
                };

                _context.Sucursales.Add(nuevaSucursal);
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