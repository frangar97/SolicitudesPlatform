using Core.Features.Base;

namespace Core.Features.Usuario
{
    public interface IUsuarioRepository:IBaseRepository<UsuarioEntity>
    {
        IEnumerable<UsuarioEntity> ObtenerUsuarios();
        UsuarioEntity? ObtenerUsuario(int usuarioId);
    }
}
