using Core.Features.Solicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class SolicitudConfiguration : IEntityTypeConfiguration<SolicitudEntity>
    {
        public void Configure(EntityTypeBuilder<SolicitudEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Zona)
                .WithMany(x => x.Solicitudes)
                .HasForeignKey(x => x.ZonaId);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Solicitudes)
                .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.TipoSolicitud)
                .WithMany(x => x.Solicitudes)
                .HasForeignKey(x => x.TipoSolicitudId);

            builder.HasOne(x => x.EstadoSolicitud)
                .WithMany(x => x.Solicitudes)
                .HasForeignKey(x => x.EstadoSolicitudId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedDate)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
