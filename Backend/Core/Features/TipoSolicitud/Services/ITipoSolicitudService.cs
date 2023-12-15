using Core.Features.TipoSolicitud.DTO;

namespace Core.Features.TipoSolicitud.Services
{
    public interface ITipoSolicitudService
    {
        IEnumerable<TipoSolicitudDTO> GetAllTiposSolicitud();
    }
}
