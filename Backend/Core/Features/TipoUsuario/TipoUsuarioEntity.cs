using Core.Features.Base;
using Core.Features.Usuario;

namespace Core.Features.TipoUsuario
{
    public class TipoUsuarioEntity:BaseEntity
    {
        public string Tipo { get; set; }
        public IEnumerable<UsuarioEntity> Usuarios { get; set; }
    }
}
