using Core.Features.Zona.DTO;

namespace Core.Features.Zona.Service
{
    public interface IZonaService
    {
        IEnumerable<ZonaDTO> GetAllZonas();

        IEnumerable<ZonaDTO> ZonaAsociadoUsuario(int usuarioId);
        IEnumerable<ZonaDTO> ZonaNoAsociadoUsuario(int usuarioId);
    }
}
