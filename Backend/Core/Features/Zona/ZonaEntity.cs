using Core.Features.Base;
using Core.Features.Solicitud;
using Core.Features.UsuarioZona;

namespace Core.Features.Zona
{
    public class ZonaEntity:BaseEntity
    {
        public string Nombre { get; set; }

        public IEnumerable<SolicitudEntity> Solicitudes { get; set; }
        public IEnumerable<UsuarioZonaEntity> UsuariosZona { get; set; }
    }
}
