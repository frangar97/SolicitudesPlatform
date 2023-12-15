using Core.Features.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Apellido)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Codigo)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Genero)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.GeneroId);

            builder.HasOne(x => x.TipoUsuario)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.TipoUsuarioId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedDate)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
