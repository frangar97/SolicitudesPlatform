using Core.Features.TipoSolicitud.DTO;
using Core.Features.TipoSolicitud.Services;
using Core.Features.Usuario.DTO;
using Core.Features.Usuario.Services;
using Core.Features.UsuarioTipoSolicitud.DTO;
using Core.Features.UsuarioTipoSolicitud.Services;
using Core.Features.UsuarioZona.DTO;
using Core.Features.UsuarioZona.Services;
using Core.Features.Zona.DTO;
using Core.Features.Zona.Service;
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
        private readonly IUsuarioTipoSolicitudService _usuarioTipoSolicitudService;
        private readonly ITipoSolicitudService _tipoSolicitudService;
        private readonly IZonaService _zonaService;

        public UsuarioController(
            IUsuarioService usuarioService,
            IUsuarioZonaService usuarioZonaService,
            IUsuarioTipoSolicitudService usuarioTipoSolicitudService,
            ITipoSolicitudService tipoSolicitudService,
            IZonaService zonaService
            )
        {
            _usuarioService = usuarioService;
            _usuarioZonaService = usuarioZonaService;
            _usuarioTipoSolicitudService = usuarioTipoSolicitudService;
            _tipoSolicitudService = tipoSolicitudService;
            _zonaService = zonaService;
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

        [HttpGet("zona/asignadas/{usuarioId}")]
        public IActionResult ZonasAsociadasUsuario(int usuarioId)
        {
            IEnumerable<ZonaDTO> zonas = _zonaService.ZonaAsociadoUsuario(usuarioId);
            return Ok(zonas);
        }

        [HttpGet("zona/noasignadas/{usuarioId}")]
        public IActionResult ZonasNoAsociadasUsuario(int usuarioId)
        {
            IEnumerable<ZonaDTO> zonas = _zonaService.ZonaNoAsociadoUsuario(usuarioId);
            return Ok(zonas);
        }

        [HttpPost("tiposolicitud/asignar")]
        public async Task<IActionResult> AsignarUsuarioTipoSolicitud(CreateUsuarioTipoSolicitudDTO createUsuarioTipoSolicitudDTO)
        {
            await _usuarioTipoSolicitudService.CrearUsuarioTipoSolicitudAsync(createUsuarioTipoSolicitudDTO);
            return Ok();
        }

        [HttpPost("tiposolicitud/remover")]
        public async Task<IActionResult> RemoverUsuarioTipoSolicitud(CreateUsuarioTipoSolicitudDTO createUsuarioTipoSolicitudDTO)
        {
            await _usuarioTipoSolicitudService.RemoverUsuarioTipoSolicitudAsync(createUsuarioTipoSolicitudDTO);
            return Ok();
        }

        [HttpGet("tiposolicitud/asignadas/{usuarioId}")]
        public IActionResult TipoSolicitudAsociadasUsuario(int usuarioId)
        {
            IEnumerable<TipoSolicitudDTO> tipoSolicitud =  _tipoSolicitudService.TipoSolicitudAsociadoUsuario(usuarioId);
            return Ok(tipoSolicitud);
        }

        [HttpGet("tiposolicitud/noasignadas/{usuarioId}")]
        public IActionResult TipoSolicitudNoAsociadasUsuario(int usuarioId)
        {
            IEnumerable<TipoSolicitudDTO> tipoSolicitud = _tipoSolicitudService.TipoSolicitudNoAsociadoUsuario(usuarioId);
            return Ok(tipoSolicitud);
        }
    }
}
