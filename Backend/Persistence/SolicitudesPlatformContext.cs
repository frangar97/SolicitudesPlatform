using Microsoft.EntityFrameworkCore;
using Core.Features.EstadoSolicitud;
using Core.Features.Genero;
using Core.Features.TipoSolicitud;
using Core.Features.TipoUsuario;
using Core.Features.Zona;
using Persistence.Configuration;

namespace Persistence
{
    public class SolicitudesPlatformContext : DbContext
    {
        public SolicitudesPlatformContext(DbContextOptions<SolicitudesPlatformContext> options):base(options)
        {
            
        }

        public DbSet<GeneroEntity> Genero { get; set; }
        public DbSet<TipoSolicitudEntity> TipoSolicitud { get; set; }
        public DbSet<TipoUsuarioEntity> TipoUsuario { get; set; }
        public DbSet<EstadoSolicitudEntity> EstadoSolicitud { get; set; }
        public DbSet<ZonaEntity> Zona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GeneroConfigurarion());
            modelBuilder.ApplyConfiguration(new TipoSolicitudConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoSolicitudConfiguration());
            modelBuilder.ApplyConfiguration(new ZonaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitudConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioTipoSolicitudConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioZonaConfiguration());

            modelBuilder.Entity<GeneroEntity>()
                .HasData(
                new GeneroEntity { Id = 1, Tipo = "Masculino" },
                new GeneroEntity { Id = 2, Tipo = "Femenino" }
                );

            modelBuilder.Entity<ZonaEntity>()
                .HasData(
                new ZonaEntity { Id = 1, Nombre = "Norte" },
                new ZonaEntity { Id = 2, Nombre = "Sur" },
                new ZonaEntity { Id = 3, Nombre = "Este" },
                new ZonaEntity { Id = 4, Nombre = "Oeste" }
                );

            modelBuilder.Entity<EstadoSolicitudEntity>()
               .HasData(
               new EstadoSolicitudEntity { Id = 1, Estado = "Pendiente" },
               new EstadoSolicitudEntity { Id = 2, Estado = "Aprobado" },
               new EstadoSolicitudEntity { Id = 3, Estado = "Cancelado" }
               );

            modelBuilder.Entity<TipoUsuarioEntity>()
               .HasData(
               new TipoUsuarioEntity { Id = 1, Tipo = "Interno" },
               new TipoUsuarioEntity { Id = 2, Tipo = "Externo" }
               );
        }
    }
}
