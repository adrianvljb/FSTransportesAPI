using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer;
using FSTransportesAPI.Features.Viajes.Dtos;
using System.Linq;

namespace FSTransportesAPI.Features.Viajes.Services
{
    public class ReporteViajeAppService
    {
        private readonly FSTransportesDbContext _context;

        public ReporteViajeAppService(FSTransportesDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReporteViajesDto>> ObtenerResumenViajes(DateTime inicio, DateTime fin)
        {
            var viajes = await _context.Viajes
                .Include(v => v.Sucursal)
                .Include(v => v.Transportista)
                .Include(v => v.Detalles)
                .AsNoTracking()
                .Where(v => v.FechaViaje.Date >= inicio.Date && v.FechaViaje.Date <= fin.Date)
                .ToListAsync();

            return viajes.Select(v => new ReporteViajesDto
            {
                IdViaje = v.IdViaje,
                Fecha = v.FechaViaje,
                // Nombres actualizados para coincidir con tu DTO
                Sucursal = v.Sucursal?.Nombre ?? "N/A",
                Transportista = v.Transportista?.Nombre ?? "N/A",
                TotalKM = v.Detalles?.Sum(d => d.DistanciaKilometros) ?? 0,
                TotalPagarTransporte = (v.Detalles?.Sum(d => d.DistanciaKilometros) ?? 0) * (v.Transportista?.TarifaPorKilometro ?? 0)
            }).ToList();
        }
    }
}