using Core.Features.Base;
using Core.Features.Usuario;

namespace Core.Features.Genero
{
    public class GeneroEntity:BaseEntity
    {
        public string Tipo { get; set; }
        public IEnumerable<UsuarioEntity> Usuarios { get; set; }
    }
}
