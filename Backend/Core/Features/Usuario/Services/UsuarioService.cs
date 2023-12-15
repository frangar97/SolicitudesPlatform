using Core.Exceptions;
using Core.Features.Base;
using Core.Features.Genero;
using Core.Features.TipoUsuario;
using Core.Features.Usuario.DTO;
using Core.Services;

namespace Core.Features.Usuario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashService _hashService;
        public UsuarioService(IUnitOfWork unitOfWork,IHashService hashService)
        {
            _unitOfWork = unitOfWork;
            _hashService = hashService;
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
    }
}
