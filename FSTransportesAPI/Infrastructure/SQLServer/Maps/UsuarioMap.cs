using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FSTransportesAPI.Infrastructure.SQLServer.Entities;

namespace FSTransportesAPI.Infrastructure.SQLServer.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            // Define explícitamente la llave primaria para resolver el error CS1061/EF
            builder.HasKey(e => e.IdUsuario);

            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Contrasena)
                .IsRequired();

            builder.Property(e => e.IdRol)
                .IsRequired();

            builder.Property(e => e.Activo)
                .IsRequired();

            // Configuración de auditoría
            builder.Property(e => e.UsuarioAgrega).IsRequired();
            builder.Property(e => e.FechaAgrega).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.UsuarioModifica);
            builder.Property(e => e.FechaModifica).HasColumnType("datetime");
        }
    }
}