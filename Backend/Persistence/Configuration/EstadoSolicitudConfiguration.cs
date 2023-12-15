using Core.Features.EstadoSolicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class EstadoSolicitudConfiguration : IEntityTypeConfiguration<EstadoSolicitudEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoSolicitudEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Estado)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
