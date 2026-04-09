using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;

namespace FSTransportesAPI.Infrastructure.SQLServer.Maps
{
    public class ViajeDetalleMap : IEntityTypeConfiguration<ViajeDetalle>
    {
        public void Configure(EntityTypeBuilder<ViajeDetalle> builder)
        {
            builder.ToTable("ViajesDetalles");

            builder.HasKey(e => e.IdViajeDetalle);

            builder.Property(e => e.DistanciaKilometros)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.TarifaSugerida)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            
            builder.Property(e => e.UsuarioAgrega).IsRequired();
            builder.Property(e => e.FechaAgrega).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UsuarioModifica);
            builder.Property(e => e.FechaModifica).HasColumnType("datetime");

            // Relaciones
            builder.HasOne(d => d.Viaje)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.IdViaje);

            builder.HasOne(d => d.Colaborador)
                .WithMany()
                .HasForeignKey(d => d.IdColaborador);
        }
    }
}