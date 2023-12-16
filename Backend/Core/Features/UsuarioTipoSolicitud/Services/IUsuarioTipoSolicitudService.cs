using Core.Features.UsuarioTipoSolicitud.DTO;

namespace Core.Features.UsuarioTipoSolicitud.Services
{
    public interface IUsuarioTipoSolicitudService
    {
        Task CrearUsuarioTipoSolicitudAsync(CreateUsuarioTipoSolicitudDTO createUsuarioTipoSolicitudDTO);
        Task RemoverUsuarioTipoSolicitudAsync(CreateUsuarioTipoSolicitudDTO createUsuarioTipoSolicitudDTO);
    }
}
