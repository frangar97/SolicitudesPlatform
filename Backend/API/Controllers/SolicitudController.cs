using Core.Features.EstadoSolicitud.DTO;
using Core.Features.EstadoSolicitud.Services;
using Core.Features.Solicitud.DTO;
using Core.Features.Solicitud.Services;
using Core.Features.TipoSolicitud.DTO;
using Core.Features.TipoSolicitud.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
            SolicitudDTO solicitudDTO = await _solicitudService.CreateSolicitud(1, createSolicitudDTO);
            return Ok(solicitudDTO);
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
    }
}
