using Core.Features.EstadoSolicitud.DTO;
using Core.Features.EstadoSolicitud.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoSolicitudController : ControllerBase
    {
        private readonly IEstadoSolicitudService _estadoSolicitudService;

        public EstadoSolicitudController(IEstadoSolicitudService estadoSolicitudService)
        {
            _estadoSolicitudService = estadoSolicitudService;
        }

        [HttpGet]
        public IActionResult GetZonas()
        {
            IEnumerable<EstadoSolicitudDTO> estadosSolicitud = _estadoSolicitudService.GetAllEstadoSolicitud();
            return Ok(estadosSolicitud);
        }
    }
}
