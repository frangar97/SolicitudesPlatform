using Core.Features.Base;
using Core.Features.Solicitud;

namespace Core.Features.EstadoSolicitud
{
    public class EstadoSolicitudEntity:BaseEntity
    {
        public string Estado { get; set; }
        public IEnumerable<SolicitudEntity> Solicitudes { get; set; }
    }
}
