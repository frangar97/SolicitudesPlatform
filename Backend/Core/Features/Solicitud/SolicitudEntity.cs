using Core.Features.Base;
using Core.Features.EstadoSolicitud;
using Core.Features.TipoSolicitud;
using Core.Features.Usuario;
using Core.Features.Zona;

namespace Core.Features.Solicitud
{
    public class SolicitudEntity : BaseEntity
    {
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoSolicitudId { get; set; }
        public int TipoSolicitudId { get; set; }
        public int ZonaId { get; set; }

        public UsuarioEntity Usuario { get; set; }
        public EstadoSolicitudEntity EstadoSolicitud { get; set; }
        public TipoSolicitudEntity TipoSolicitud { get; set; }
        public ZonaEntity Zona { get; set; }
    }
}
