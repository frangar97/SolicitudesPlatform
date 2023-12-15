using Core.Features.Base;
using Core.Features.TipoSolicitud;
using Core.Features.Usuario;

namespace Core.Features.UsuarioTipoSolicitud
{
    public class UsuarioTipoSolicitudEntity : BaseEntity
    {
        public bool Activo { get; set; }
        public int UsuarioId { get; set; }
        public int TipoSolicitudId { get; set; }

        public UsuarioEntity Usuario { get; set; }
        public TipoSolicitudEntity TipoSolicitud { get; set; }
    }
}
