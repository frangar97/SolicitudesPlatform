using Core.Exceptions;
using Core.Features.Base;
using Core.Features.Genero;
using Core.Features.Genero.DTO;
using Core.Features.TipoUsuario;
using Core.Features.Usuario.DTO;
using Core.Services;

namespace Core.Features.Usuario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hashService;
        private IJwtService _jwtService;
        public UsuarioService(IUnitOfWork unitOfWork,IHashService hashService, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _hashService = hashService;
            _jwtService = jwtService;
        }
        public async Task<UsuarioDTO> CreateUsuario(CreateUsuarioDTO createUsuarioDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FirstOrDefaultAsync(x => x.Codigo == createUsuarioDTO.Codigo);
            if (usuarioEntity != null)
            {
                throw new BusinessException($"el usuario {createUsuarioDTO.Codigo} ya se encuentra registado");
            }

            GeneroEntity? generoEntity = await _unitOfWork.GeneroRepository.FirstOrDefaultAsync(x => x.Tipo == createUsuarioDTO.Genero);
            if (generoEntity == null)
            {
                throw new BusinessException($"el genero ${createUsuarioDTO.Genero} no existe");
            }

            TipoUsuarioEntity? tipoUsuarioEntity = await _unitOfWork.TipoUsuarioRepository.FirstOrDefaultAsync(x => x.Tipo == createUsuarioDTO.TipoUsuario);
            if (tipoUsuarioEntity == null)
            {
                throw new BusinessException($"el tipo usuario ${createUsuarioDTO.TipoUsuario} no existe");
            }

            string passwordEncriptada = _hashService.GenerateHash(createUsuarioDTO.Password);

            UsuarioEntity nuevoUsuario = new UsuarioEntity
            {
                Nombre = createUsuarioDTO.Nombre,
                Apellido = createUsuarioDTO.Apellido,
                Codigo = createUsuarioDTO.Codigo,
                Password = passwordEncriptada,
                GeneroId = generoEntity.Id,
                TipoUsuarioId = tipoUsuarioEntity.Id
            };

            await _unitOfWork.UsuarioRepository.AddAsync(nuevoUsuario);
            await _unitOfWork.SaveChangesAsync();

            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = nuevoUsuario.Id,
                Nombre = createUsuarioDTO.Nombre,
                Apellido = createUsuarioDTO.Apellido,
                Codigo = createUsuarioDTO.Codigo,
                Genero = generoEntity.Tipo,
                TipoUsuario = tipoUsuarioEntity.Tipo
            };

            return usuarioDTO;
        }

        public async Task<string> LoginUsuarioAsync(LoginUsuarioDTO loginUsuarioDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FirstOrDefaultAsync(x => x.Codigo == loginUsuarioDTO.Codigo);
            if (usuarioEntity == null)
            {
                throw new BusinessException("Usuario o contraseña incorrectos.");
            }

            bool esCredencialDiferente = !(_hashService.CompareStringHash(loginUsuarioDTO.Password, usuarioEntity.Password));
            if (esCredencialDiferente)
            {
                throw new BusinessException("Usuario o contraseña incorrectos.");
            }

            string token = _jwtService.GenerateJWT(usuarioEntity.Id, usuarioEntity.Codigo);
            return token;
        }

        public IEnumerable<GeneroDTO> ObtenerGeneros()
        {
            return _unitOfWork.GeneroRepository.GetAllSelect(x => new GeneroDTO { Id = x.Id, Tipo = x.Tipo });
        }

        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            return _unitOfWork.UsuarioRepository.ObtenerUsuarios().Select(x => new UsuarioDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Codigo = x.Codigo,
                Genero = x.Genero.Tipo,
                TipoUsuario = x.TipoUsuario.Tipo,
                UrlImagen = x.ImagenUrl
            });
        }

        public async Task UpdateUsuarioImage(int usuarioId, string imagenUrl)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FindByIdAsync(usuarioId);
            if (usuarioEntity == null)
            {
                throw new BusinessException($"el usuario con el id{usuarioId} no existe");
            }

            usuarioEntity.ImagenUrl = imagenUrl;
            _unitOfWork.UsuarioRepository.Update(usuarioEntity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
