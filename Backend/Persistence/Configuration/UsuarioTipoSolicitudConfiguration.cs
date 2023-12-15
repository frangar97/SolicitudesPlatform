using Core.Features.UsuarioTipoSolicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UsuarioTipoSolicitudConfiguration : IEntityTypeConfiguration<UsuarioTipoSolicitudEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioTipoSolicitudEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(e => e.Usuario)
                .WithMany(e => e.UsuariosTipoSolicitud)
                .HasForeignKey(e => e.UsuarioId);

            builder
                .HasOne(x => x.TipoSolicitud)
                .WithMany(x => x.UsuariosTipoSolicitud)
                .HasForeignKey(x => x.TipoSolicitudId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedDate)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
