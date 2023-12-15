using Core.Features.TipoSolicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TipoSolicitudConfiguration : IEntityTypeConfiguration<TipoSolicitudEntity>
    {
        public void Configure(EntityTypeBuilder<TipoSolicitudEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedDate)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
