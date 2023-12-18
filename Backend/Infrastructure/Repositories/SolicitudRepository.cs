using Core.Features.EstadoSolicitud.Enums;
using Core.Features.Solicitud;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories
{
    public class SolicitudRepository : BaseRepository<SolicitudEntity>, ISolicitudRepository
    {
        public SolicitudRepository(SolicitudesPlatformContext context) : base(context)
        {
        }


        public IEnumerable<SolicitudEntity> ObtenerSolicitudesAprobacion(IEnumerable<int> zonas, IEnumerable<int> tipos)
        {
            return _entities.Include(x => x.EstadoSolicitud)
                .Include(x => x.TipoSolicitud)
                .Include(x => x.Zona)
                .Include(x=>x.Usuario)
                .Where(x => zonas.Contains(x.ZonaId) && tipos.Contains(x.TipoSolicitudId) && x.EstadoSolicitudId == (int)EstadoSolicitudEnum.Pendiente)
                .AsEnumerable();
        }

        public IEnumerable<SolicitudEntity> ObtenerSolicitudesUsuario(int usuarioId)
        {
            return _entities.Include(x => x.EstadoSolicitud)
                .Include(x => x.TipoSolicitud)
                .Include(x => x.Zona)
                .Include(x => x.Usuario)
                .Where(x => x.UsuarioId == usuarioId)
                .AsEnumerable();
        }
    }
}
