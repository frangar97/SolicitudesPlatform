using Core.Features.TipoUsuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<TipoUsuarioEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
