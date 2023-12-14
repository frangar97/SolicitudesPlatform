using Core.Features.Zona;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ZonaConfiguration : IEntityTypeConfiguration<ZonaEntity>
    {
        public void Configure(EntityTypeBuilder<ZonaEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
