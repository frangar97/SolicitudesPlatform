using Core.Exceptions;
using Core.Features.Base;
using Core.Features.Usuario;
using Core.Features.UsuarioZona.DTO;
using Core.Features.Zona;

namespace Core.Features.UsuarioZona.Services
{
    public class UsuarioZonaService : IUsuarioZonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioZonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CrearUsuarioZonaAsync(CreateUsuarioZonaDTO createUsuarioZonaDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FindByIdAsync(createUsuarioZonaDTO.UsuarioId);
            if (usuarioEntity == null)
            {
                throw new BusinessException("el usuario no existe");
            }

            ZonaEntity? zonaEntity = await _unitOfWork.ZonaRepository.FindByIdAsync(createUsuarioZonaDTO.ZonaId);
            if (zonaEntity == null)
            {
                throw new BusinessException("la zona no existe");
            }

            UsuarioZonaEntity? usuarioZonaEntity = await _unitOfWork.UsuarioZonaRepository.FirstOrDefaultAsync(x => x.UsuarioId == createUsuarioZonaDTO.UsuarioId && x.ZonaId == createUsuarioZonaDTO.ZonaId);
            if (usuarioZonaEntity == null)
            {
                usuarioZonaEntity = new UsuarioZonaEntity { UsuarioId = createUsuarioZonaDTO.UsuarioId, ZonaId = createUsuarioZonaDTO.ZonaId };
                await _unitOfWork.UsuarioZonaRepository.AddAsync(usuarioZonaEntity);
            }
            else
            {
                usuarioZonaEntity.Activo = true;
                usuarioZonaEntity.ModifiedDate = DateTime.Now;
                _unitOfWork.UsuarioZonaRepository.Update(usuarioZonaEntity);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoverUsuarioZonaAsync(CreateUsuarioZonaDTO createUsuarioZonaDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FindByIdAsync(createUsuarioZonaDTO.UsuarioId);
            if (usuarioEntity == null)
            {
                throw new BusinessException("el usuario no existe");
            }

            ZonaEntity? zonaEntity = await _unitOfWork.ZonaRepository.FindByIdAsync(createUsuarioZonaDTO.ZonaId);
            if (zonaEntity == null)
            {
                throw new BusinessException("la zona no existe");
            }

            UsuarioZonaEntity? usuarioZonaEntity = await _unitOfWork.UsuarioZonaRepository.FirstOrDefaultAsync(x => x.UsuarioId == createUsuarioZonaDTO.UsuarioId && x.ZonaId == createUsuarioZonaDTO.ZonaId);
            if (usuarioZonaEntity != null)
            {
                usuarioZonaEntity.Activo = false;
                usuarioZonaEntity.ModifiedDate = DateTime.Now;
                _unitOfWork.UsuarioZonaRepository.Update(usuarioZonaEntity);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
