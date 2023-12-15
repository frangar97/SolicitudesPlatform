using Core.Features.Base;
using Core.Features.Solicitud;
using Core.Features.UsuarioTipoSolicitud;

namespace Core.Features.TipoSolicitud
{
    public class TipoSolicitudEntity:BaseEntity
    {
        public string Tipo { get; set; }
        public IEnumerable<SolicitudEntity> Solicitudes { get; set; }
        public IEnumerable<UsuarioTipoSolicitudEntity> UsuariosTipoSolicitud { get; set; }
    }
}
