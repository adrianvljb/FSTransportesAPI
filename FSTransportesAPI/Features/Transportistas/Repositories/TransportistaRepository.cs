using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Features.Transportistas.Domain.Repositories;
using System.Threading.Tasks;

namespace FSTransportesAPI.Features.Transportistas.Repositories
{
    public class TransportistaRepository : ITransportistaRepository
    {
        private readonly FSTransportesDbContext _context;

        public TransportistaRepository(FSTransportesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteNombreAsync(string nombre)
        {
            // Verificamos si existe el nombre ignorando mayúsculas/minúsculas y espacios en blanco
            return await _context.Transportistas
                .AnyAsync(t => t.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
        }

        public async Task<int> AgregarAsync(Transportista transportista)
        {
            _context.Transportistas.Add(transportista);
            await _context.SaveChangesAsync();
            
            // Retorna la llave primaria autogenerada por SQL Server
            return transportista.IdTransportista; 
        }
    }
}