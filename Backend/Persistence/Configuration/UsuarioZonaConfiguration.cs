using Core.Features.UsuarioZona;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UsuarioZonaConfiguration : IEntityTypeConfiguration<UsuarioZonaEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioZonaEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(e => e.Usuario)
                .WithMany(e => e.UsuariosZona)
                .HasForeignKey(e => e.UsuarioId);

            builder
                .HasOne(x => x.Zona)
                .WithMany(x => x.UsuariosZona)
                .HasForeignKey(x => x.ZonaId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedDate)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
