using Core.Features.Genero;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class GeneroConfigurarion : IEntityTypeConfiguration<GeneroEntity>
    {
        public void Configure(EntityTypeBuilder<GeneroEntity> builder)
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
