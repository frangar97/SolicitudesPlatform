using Microsoft.EntityFrameworkCore;
using Core.Features.EstadoSolicitud;
using Core.Features.Genero;
using Core.Features.TipoSolicitud;
using Core.Features.TipoUsuario;
using Core.Features.Zona;

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
    }
}
