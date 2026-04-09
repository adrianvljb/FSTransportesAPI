using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer;

// Usings - Feature: Viajes
using FSTransportesAPI.Features.Viajes.Domain.DomainService;
using FSTransportesAPI.Features.Viajes.Services;
using FSTransportesAPI.Features.Viajes.Domain.Repositories;
using FSTransportesAPI.Features.Viajes.Repositories;

// Usings - Feature: Colaboradores
using FSTransportesAPI.Features.Colaboradores.Domain.DomainService;
using FSTransportesAPI.Features.Colaboradores.Services;

// Usings - Feature: Sucursales
using FSTransportesAPI.Features.Sucursales.Services;
// Nota: Ajusta este namespace si tu SucursalAppDomain está en otra carpeta
using FSTransportesAPI.Features.Sucursales.Domain.DomainService; 

// Usings - Feature: Transportistas
using FSTransportesAPI.Features.Transportistas.Domain.DomainService;
using FSTransportesAPI.Features.Transportistas.Services;
using FSTransportesAPI.Features.Transportistas.Domain.Repositories;
using FSTransportesAPI.Features.Transportistas.Repositories;

namespace FSTransportesAPI.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFSTransportesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCoreApi();
            services.AddInfrastructure(configuration);
            services.AddFeatures();

            return services;
        }

        private static void AddCoreApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FSTransportesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddFeatures(this IServiceCollection services)
        {
            #region Feature: Viajes
            services.AddScoped<IViajeAppService, ViajeAppService>();
            services.AddScoped<ViajeAppDomain>();
            // Ajustado al nombre de tu última actualización del servicio de reportes
            services.AddScoped<ReporteViajeAppService>(); 
            services.AddScoped<IViajeRepository, ViajeRepository>();
            #endregion

            #region Feature: Colaboradores
            services.AddScoped<ColaboradorAppService>();
            services.AddScoped<ColaboradorAppDomain>();
            #endregion

            #region Feature: Sucursales
            services.AddScoped<SucursalAppService>();
            services.AddScoped<SucursalAppDomain>();
            #endregion

            #region Feature: Transportistas
            services.AddScoped<TransportistaAppService>();
            services.AddScoped<TransportistaAppDomain>();
            services.AddScoped<ITransportistaRepository, TransportistaRepository>();
            #endregion
        }
    }
}