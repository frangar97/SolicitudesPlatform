using Core.Features.TipoUsuario.DTO;
using Core.Features.TipoUsuario.Services;
using Core.Features.Usuario.DTO;
using Core.Features.Usuario.Services;
using Infrastructure.MediaUpload;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITipoUsuarioService _tipoUsuarioService;
        private readonly IMediaUpload _mediaUpload;
        public AuthController(IUsuarioService usuarioService, IMediaUpload mediaUpload,ITipoUsuarioService tipoUsuarioService)
        {
            _usuarioService = usuarioService;
            _tipoUsuarioService = tipoUsuarioService;
            _mediaUpload = mediaUpload;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegisterUsuario([FromForm] CreateUsuarioDTO createUsuarioDTO)
        {
            UsuarioDTO usuario = await _usuarioService.CreateUsuario(createUsuarioDTO);

            if (Request.Form.Files.Count > 0)
            {
                string imageUrl = _mediaUpload.UploadImage(Request.Form.Files[0]);
                await _usuarioService.UpdateUsuarioImage(usuario.Id, imageUrl);
                usuario.UrlImagen = imageUrl;
            }

            return Ok(usuario);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioDTO loginUsuarioDTO)
        {
            string token = await _usuarioService.LoginUsuarioAsync(loginUsuarioDTO);
            return Ok(new { token = token });
        }

        [HttpGet("tipousuario")]
        public IActionResult ObtenerTiposDeUsuario()
        {
            IEnumerable<TipoUsuarioDTO> tiposUsuario = _tipoUsuarioService.GetAllTiposUsuario();
            return Ok(tiposUsuario);
        }
    }
}
