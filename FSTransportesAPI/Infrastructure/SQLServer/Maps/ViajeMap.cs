using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;

namespace FSTransportesAPI.Infrastructure.SQLServer.Maps
{
    public class ViajeMap : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> builder)
        {
            builder.ToTable("Viajes");

            builder.HasKey(e => e.IdViaje);

            builder.Property(e => e.FechaViaje)
                .HasColumnType("datetime")
                .IsRequired();

            // Auditoría
            builder.Property(e => e.UsuarioAgrega).IsRequired();
            builder.Property(e => e.FechaAgrega).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UsuarioModifica);
            builder.Property(e => e.FechaModifica).HasColumnType("datetime");

            // Relaciones
            builder.HasOne(d => d.Sucursal)
                .WithMany()
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Transportista)
                .WithMany()
                .HasForeignKey(d => d.IdTransportista)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.UsuarioRegistro)
                .WithMany()
                .HasForeignKey(d => d.IdUsuarioRegistro)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Detalles)
                .WithOne(p => p.Viaje)
                .HasForeignKey(p => p.IdViaje);
        }
    }
}