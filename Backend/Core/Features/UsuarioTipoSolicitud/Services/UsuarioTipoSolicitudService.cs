using Core.Exceptions;
using Core.Features.Base;
using Core.Features.Usuario;
using Core.Features.UsuarioTipoSolicitud.DTO;
using Core.Features.TipoSolicitud;

namespace Core.Features.UsuarioTipoSolicitud.Services
{
    public class UsuarioTipoSolicitudService:IUsuarioTipoSolicitudService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioTipoSolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CrearUsuarioTipoSolicitudAsync(CreateUsuarioTipoSolicitudDTO createUsuarioTipoSolicitudDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FindByIdAsync(createUsuarioTipoSolicitudDTO.UsuarioId);
            if (usuarioEntity == null)
            {
                throw new BusinessException("el usuario no existe");
            }

            TipoSolicitudEntity? tipoSolicitudEntity = await _unitOfWork.TipoSolicitudRepository.FindByIdAsync(createUsuarioTipoSolicitudDTO.TipoSolicitudId);
            if (tipoSolicitudEntity == null)
            {
                throw new BusinessException("el tipo de solicitud no existe");
            }

            UsuarioTipoSolicitudEntity? usuarioTipoSolicitudEntity = await _unitOfWork.UsuarioTipoSolicitudRepository.FirstOrDefaultAsync(x => x.UsuarioId == createUsuarioTipoSolicitudDTO.UsuarioId && x.TipoSolicitudId == createUsuarioTipoSolicitudDTO.TipoSolicitudId);
            if (usuarioTipoSolicitudEntity == null)
            {
                usuarioTipoSolicitudEntity = new UsuarioTipoSolicitudEntity { UsuarioId = createUsuarioTipoSolicitudDTO.UsuarioId, TipoSolicitudId = createUsuarioTipoSolicitudDTO.TipoSolicitudId };
                await _unitOfWork.UsuarioTipoSolicitudRepository.AddAsync(usuarioTipoSolicitudEntity);
            }
            else
            {
                usuarioTipoSolicitudEntity.Activo = true;
                usuarioTipoSolicitudEntity.ModifiedDate = DateTime.Now;
                _unitOfWork.UsuarioTipoSolicitudRepository.Update(usuarioTipoSolicitudEntity);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoverUsuarioTipoSolicitudAsync(CreateUsuarioTipoSolicitudDTO createUsuarioTipoSolicitudDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FindByIdAsync(createUsuarioTipoSolicitudDTO.UsuarioId);
            if (usuarioEntity == null)
            {
                throw new BusinessException("el usuario no existe");
            }

            TipoSolicitudEntity? tipoSolicitudEntity = await _unitOfWork.TipoSolicitudRepository.FindByIdAsync(createUsuarioTipoSolicitudDTO.TipoSolicitudId);
            if (tipoSolicitudEntity == null)
            {
                throw new BusinessException("el tipo de solicitud no existe");
            }

            UsuarioTipoSolicitudEntity? usuarioTipoSolicitudEntity = await _unitOfWork.UsuarioTipoSolicitudRepository.FirstOrDefaultAsync(x => x.UsuarioId == createUsuarioTipoSolicitudDTO.UsuarioId && x.TipoSolicitudId == createUsuarioTipoSolicitudDTO.TipoSolicitudId);

            if (usuarioTipoSolicitudEntity != null)
            {
                usuarioTipoSolicitudEntity.Activo = false;
                usuarioTipoSolicitudEntity.ModifiedDate = DateTime.Now;
                _unitOfWork.UsuarioTipoSolicitudRepository.Update(usuarioTipoSolicitudEntity);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
