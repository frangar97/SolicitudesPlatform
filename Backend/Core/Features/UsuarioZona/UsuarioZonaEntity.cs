using Core.Features.Base;
using Core.Features.Usuario;
using Core.Features.Zona;

namespace Core.Features.UsuarioZona
{
    public class UsuarioZonaEntity:BaseEntity
    {
        public bool Activo { get; set; }
        public int UsuarioId { get; set; }
        public int ZonaId { get; set; }

        public UsuarioEntity Usuario { get; set; }
        public ZonaEntity Zona { get; set; }
    }
}
