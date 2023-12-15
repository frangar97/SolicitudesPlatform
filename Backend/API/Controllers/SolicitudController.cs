using Core.Features.EstadoSolicitud.DTO;
using Core.Features.EstadoSolicitud.Services;
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

        public SolicitudController(IEstadoSolicitudService estadoSolicitudService,ITipoSolicitudService tipoSolicitudService)
        {
            _estadoSolicitudService = estadoSolicitudService;
            _tipoSolicitudService = tipoSolicitudService;
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
