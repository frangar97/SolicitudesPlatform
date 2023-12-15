using Core.Features.EstadoSolicitud.DTO;

namespace Core.Features.EstadoSolicitud.Services
{
    public interface IEstadoSolicitudService
    {
        IEnumerable<EstadoSolicitudDTO> GetAllEstadoSolicitud();
    }
}
