using Core.Features.Usuario.DTO;
using Core.Features.Usuario.Services;
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
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            IEnumerable<UsuarioDTO> usuarios = _usuarioService.ObtenerUsuarios();
            return Ok(usuarios);
        }
    }
}
