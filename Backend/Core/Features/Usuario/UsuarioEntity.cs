using Core.Features.Base;
using Core.Features.Genero;
using Core.Features.TipoUsuario;

namespace Core.Features.Usuario
{
    public class UsuarioEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Codigo { get; set; }
        public string Password { get; set; }
        public string ImagenUrl { get; set; }
        public int GeneroId { get; set; }
        public int TipoUsuarioId { get; set; }

        public GeneroEntity Genero { get; set; }
        public TipoUsuarioEntity TipoUsuario { get; set; }
    }
}
