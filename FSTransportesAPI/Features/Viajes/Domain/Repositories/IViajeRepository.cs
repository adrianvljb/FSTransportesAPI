using FSTransportesAPI.Infrastructure.SQLServer.Entities;

namespace FSTransportesAPI.Features.Viajes.Domain.Repositories
{
    public interface IViajeRepository
    {
        Task<Usuario?> ObtenerUsuarioPorIdAsync(int idUsuario);
        
        Task<bool> ExisteViajeColaboradorEnFechaAsync(int idColaborador, DateTime fecha);
        
        Task<int> AgregarViajeAsync(Viaje viaje);
    }
}