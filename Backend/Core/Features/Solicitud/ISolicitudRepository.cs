using Core.Features.Base;

namespace Core.Features.Solicitud
{
    public interface ISolicitudRepository:IBaseRepository<SolicitudEntity>
    {
        IEnumerable<SolicitudEntity> ObtenerSolicitudesAprobacion(IEnumerable<int> zonas,IEnumerable<int> tipos);
        IEnumerable<SolicitudEntity> ObtenerSolicitudesUsuario(int usuarioId);
    }
}
