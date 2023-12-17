using Core.Features.TipoSolicitud.DTO;

namespace Core.Features.TipoSolicitud.Services
{
    public interface ITipoSolicitudService
    {
        IEnumerable<TipoSolicitudDTO> GetAllTiposSolicitud();
        Task<TipoSolicitudDTO> CreateTipoSolicitud(CreateTipoSolicitudDTO createTipoSolicitudDTO);
        IEnumerable<TipoSolicitudDTO> TipoSolicitudAsociadoUsuario(int usuarioId);
        IEnumerable<TipoSolicitudDTO> TipoSolicitudNoAsociadoUsuario(int usuarioId);
    }
}
