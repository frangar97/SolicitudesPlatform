using Core.Features.Usuario.DTO;
using Core.Features.Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegisterUsuario([FromBody]CreateUsuarioDTO createUsuarioDTO)
        {
            UsuarioDTO usuario = await _usuarioService.CreateUsuario(createUsuarioDTO);
            return Ok(usuario);
        }
    }
}
