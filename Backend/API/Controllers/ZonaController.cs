using Core.Features.Zona.DTO;
using Core.Features.Zona.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaService _zonaService;

        public ZonaController(IZonaService zonaService)
        {
            _zonaService = zonaService;
        }

        [HttpGet]
        public IActionResult GetZonas()
        {
            IEnumerable<ZonaDTO> zonas = _zonaService.GetAllZonas();
            return Ok(zonas);
        }
    }
}
