using Core.Features.TipoUsuario.DTO;

namespace Core.Features.TipoUsuario.Services
{
    public interface ITipoUsuarioService
    {
        IEnumerable<TipoUsuarioDTO> GetAllTiposUsuario();
    }
}
