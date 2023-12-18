using Core.Features.Solicitud.DTO;

namespace Core.Features.Solicitud.Services
{
    public interface ISolicitudService
    {
        Task<SolicitudDTO> CreateSolicitud(int usuarioId,CreateSolicitudDTO createSolicitudDTO);
        Task AprobarSolicitud(int solicitudId);
        Task CancelarSolicitud(int solicitudId);
        IEnumerable<SolicitudDTO> ObtnerSolicitudesAprobacionUsuario(int usuarioId);
        IEnumerable<SolicitudDTO> ObtnerSolicitudesUsuario(int usuarioId);
    }
}
