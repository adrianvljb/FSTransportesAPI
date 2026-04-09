using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;

namespace FSTransportesAPI.Infrastructure.SQLServer.Maps
{
    public class ColaboradorSucursalMap : IEntityTypeConfiguration<ColaboradorSucursal>
    {
        public void Configure(EntityTypeBuilder<ColaboradorSucursal> builder)
        {
            builder.ToTable("ColaboradoresSucursales");

            builder.HasKey(e => e.IdColaboradorSucursal);

            builder.Property(e => e.DistanciaKilometros)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            
            builder.Property(e => e.UsuarioAgrega).IsRequired();
            builder.Property(e => e.FechaAgrega).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UsuarioModifica);
            builder.Property(e => e.FechaModifica).HasColumnType("datetime");

           
            builder.HasOne(d => d.Colaborador)
                .WithMany()
                .HasForeignKey(d => d.IdColaborador)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Sucursal)
                .WithMany()
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}