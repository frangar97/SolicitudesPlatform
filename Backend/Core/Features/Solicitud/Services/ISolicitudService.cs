using Core.Features.Solicitud.DTO;

namespace Core.Features.Solicitud.Services
{
    public interface ISolicitudService
    {
        Task<SolicitudDTO> CreateSolicitud(int usuarioId,CreateSolicitudDTO createSolicitudDTO);
    }
}
