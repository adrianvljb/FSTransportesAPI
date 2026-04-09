using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;

namespace FSTransportesAPI.Infrastructure.SQLServer.Maps
{
    public class TransportistaMap : IEntityTypeConfiguration<Transportista>
    {
        public void Configure(EntityTypeBuilder<Transportista> builder)
        {
            builder.ToTable("Transportistas");
            builder.HasKey(e => e.IdTransportista);

            builder.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsRequired();

            // CORRECCIÓN: Cambiamos TarifaPorKM por TarifaPorKilometro
            builder.Property(e => e.TarifaPorKilometro)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.Activo)
                .IsRequired();

            builder.Property(e => e.UsuarioAgrega).IsRequired();
            builder.Property(e => e.FechaAgrega).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UsuarioModifica);
            builder.Property(e => e.FechaModifica).HasColumnType("datetime");
        }
    }
}