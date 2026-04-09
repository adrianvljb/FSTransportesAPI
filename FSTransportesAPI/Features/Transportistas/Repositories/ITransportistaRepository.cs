using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using System.Threading.Tasks;

namespace FSTransportesAPI.Features.Transportistas.Domain.Repositories
{
    public interface ITransportistaRepository
    {
        Task<bool> ExisteNombreAsync(string nombre);
        Task<int> AgregarAsync(Transportista transportista);
    }
}