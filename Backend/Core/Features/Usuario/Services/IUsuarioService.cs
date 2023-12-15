using Core.Features.Usuario.DTO;

namespace Core.Features.Usuario.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> CreateUsuario(CreateUsuarioDTO createUsuarioDTO);
    }
}
