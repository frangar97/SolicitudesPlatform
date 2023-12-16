using Core.Features.UsuarioZona.DTO;

namespace Core.Features.UsuarioZona.Services
{
    public interface IUsuarioZonaService
    {
        Task CrearUsuarioZonaAsync(CreateUsuarioZonaDTO createUsuarioZonaDTO);
        Task RemoverUsuarioZonaAsync(CreateUsuarioZonaDTO createUsuarioZonaDTO);
    }
}
