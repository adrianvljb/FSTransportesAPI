using Microsoft.EntityFrameworkCore;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;
using FSTransportesAPI.Infrastructure.SQLServer.Maps;

namespace FSTransportesAPI.Infrastructure.SQLServer
{
    public class FSTransportesDbContext : DbContext
    {
        public FSTransportesDbContext(DbContextOptions<FSTransportesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<ViajeDetalle> ViajesDetalles { get; set; }
        public DbSet<Transportista> Transportistas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<ColaboradorSucursal> ColaboradoresSucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } // Asegúrate de tener esta línea

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // REGISTRO DE MAPAS
            
            modelBuilder.ApplyConfiguration(new UsuarioMap()); 

            modelBuilder.ApplyConfiguration(new ViajeMap());
            modelBuilder.ApplyConfiguration(new ViajeDetalleMap());
            modelBuilder.ApplyConfiguration(new TransportistaMap());
            modelBuilder.ApplyConfiguration(new SucursalMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new ColaboradorSucursalMap());
        }
    }
}