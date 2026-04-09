using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Features.Viajes.Domain.Repositories;

namespace FSTransportesAPI.Features.Viajes.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly FSTransportesDbContext _context;

        public ViajeRepository(FSTransportesDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerUsuarioPorIdAsync(int idUsuario)
{
    
    return await _context.Usuarios
        .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
}

        public async Task<bool> ExisteViajeColaboradorEnFechaAsync(int idColaborador, DateTime fecha)
        {
            return await _context.ViajesDetalles
                .AnyAsync(vd => vd.IdColaborador == idColaborador
                             && vd.Viaje!.FechaViaje.Date == fecha.Date);
        }

        public async Task<int> AgregarViajeAsync(Viaje viaje)
        {
            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();
            
            // Retorna el ID que SQL Server acaba de generar
            return viaje.IdViaje; 
        }
    }
}