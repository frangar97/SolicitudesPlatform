using Core.Features.EstadoSolicitud.DTO;
using Core.Features.EstadoSolicitud.Services;
using Core.Features.Solicitud.DTO;
using Core.Features.Solicitud.Services;
using Core.Features.TipoSolicitud.DTO;
using Core.Features.TipoSolicitud.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly IEstadoSolicitudService _estadoSolicitudService;
        private readonly ITipoSolicitudService _tipoSolicitudService;
        private readonly ISolicitudService _solicitudService;

        public SolicitudController(IEstadoSolicitudService estadoSolicitudService,ITipoSolicitudService tipoSolicitudService,ISolicitudService solicitudService)
        {
            _estadoSolicitudService = estadoSolicitudService;
            _tipoSolicitudService = tipoSolicitudService;
            _solicitudService = solicitudService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSolicitud([FromBody] CreateSolicitudDTO createSolicitudDTO)
        {
            int usuarioId = Convert.ToInt32(HttpContext.User.FindFirstValue("UserID"));
            SolicitudDTO solicitudDTO = await _solicitudService.CreateSolicitud(usuarioId, createSolicitudDTO);
            return Ok(solicitudDTO);
        }

        [HttpPatch("aprobar/{id}")]
        public async Task<IActionResult> AprobarSolicitud(int id)
        {
            await _solicitudService.AprobarSolicitud(id);
            return Ok();
        }

        [HttpPatch("cancelar/{id}")]
        public async Task<IActionResult> CancelarSolicitud(int id)
        {
            await _solicitudService.CancelarSolicitud(id);
            return Ok();
        }

        [HttpGet("estados")]
        public IActionResult GetEstadosSolicitud()
        {
            IEnumerable<EstadoSolicitudDTO> estadosSolicitud = _estadoSolicitudService.GetAllEstadoSolicitud();
            return Ok(estadosSolicitud);
        }

        [HttpGet("tipos")]
        public IActionResult GetTiposSolicitud()
        {
            IEnumerable<TipoSolicitudDTO> tipoSolicitud = _tipoSolicitudService.GetAllTiposSolicitud();
            return Ok(tipoSolicitud);
        }

        [HttpPost("tipos")]
        public async Task<IActionResult> CreateTipoSolicitud(CreateTipoSolicitudDTO createTipoSolicitudDTO)
        {
            TipoSolicitudDTO tipoSolicitud = await _tipoSolicitudService.CreateTipoSolicitud(createTipoSolicitudDTO);
            return Ok(tipoSolicitud);
        }
    }
}
