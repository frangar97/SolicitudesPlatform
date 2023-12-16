using Core.Features.Usuario.DTO;
using Core.Features.Usuario.Services;
using Core.Features.UsuarioZona.DTO;
using Core.Features.UsuarioZona.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioZonaService _usuarioZonaService;
        public UsuarioController(IUsuarioService usuarioService,IUsuarioZonaService usuarioZonaService)
        {
            _usuarioService = usuarioService;
            _usuarioZonaService = usuarioZonaService;
        }

        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            IEnumerable<UsuarioDTO> usuarios = _usuarioService.ObtenerUsuarios();
            return Ok(usuarios);
        }

        [HttpPost("zona/asignar")]
        public async Task<IActionResult> AsignarUsuarioZona(CreateUsuarioZonaDTO createUsuarioZonaDTO)
        {
            await _usuarioZonaService.CrearUsuarioZonaAsync(createUsuarioZonaDTO);
            return Ok();
        }

        [HttpPost("zona/remover")]
        public async Task<IActionResult> RemoverUsuarioZona(CreateUsuarioZonaDTO createUsuarioZonaDTO)
        {
            await _usuarioZonaService.RemoverUsuarioZonaAsync(createUsuarioZonaDTO);
            return Ok();
        }
    }
}
