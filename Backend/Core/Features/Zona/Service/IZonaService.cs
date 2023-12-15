using Core.Features.Zona.DTO;

namespace Core.Features.Zona.Service
{
    public interface IZonaService
    {
        IEnumerable<ZonaDTO> GetAllZonas();
    }
}
