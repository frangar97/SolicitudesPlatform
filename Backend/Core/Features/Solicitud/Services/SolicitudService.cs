using Core.Exceptions;
using Core.Features.Base;
using Core.Features.EstadoSolicitud.Enums;
using Core.Features.Solicitud.DTO;
using Core.Features.TipoSolicitud;
using Core.Features.Usuario;
using Core.Features.Zona;

namespace Core.Features.Solicitud.Services
{
    public class SolicitudService : ISolicitudService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AprobarSolicitud(int solicitudId)
        {
            SolicitudEntity? solicitudEntity = await _unitOfWork.SolicitudRepository.FindByIdAsync(solicitudId);
            if(solicitudEntity == null)
            {
                throw new BusinessException("la solicitud no existe");
            }

            solicitudEntity.EstadoSolicitudId = (int)EstadoSolicitudEnum.Aprobado;
            solicitudEntity.ModifiedDate = DateTime.Now;

            _unitOfWork.SolicitudRepository.Update(solicitudEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CancelarSolicitud(int solicitudId)
        {
            SolicitudEntity? solicitudEntity = await _unitOfWork.SolicitudRepository.FindByIdAsync(solicitudId);
            if (solicitudEntity == null)
            {
                throw new BusinessException("la solicitud no existe");
            }

            solicitudEntity.EstadoSolicitudId = (int)EstadoSolicitudEnum.Cancelado;
            solicitudEntity.ModifiedDate = DateTime.Now;

            _unitOfWork.SolicitudRepository.Update(solicitudEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SolicitudDTO> CreateSolicitud(int usuarioId, CreateSolicitudDTO createSolicitudDTO)
        {
            UsuarioEntity? usuarioEntity = await _unitOfWork.UsuarioRepository.FindByIdAsync(usuarioId);
            if (usuarioEntity == null)
            {
                throw new BusinessException($"el usuario no existe");
            }

            TipoSolicitudEntity? tipoSolicitudEntity = await _unitOfWork.TipoSolicitudRepository.FirstOrDefaultAsync(x => x.Tipo.ToUpper() == createSolicitudDTO.TipoSolicitud.ToUpper());
            if (tipoSolicitudEntity == null)
            {
                throw new BusinessException($"el tipo de solicitud {createSolicitudDTO.TipoSolicitud} no existe");
            }

            ZonaEntity? zonaEntity = await _unitOfWork.ZonaRepository.FirstOrDefaultAsync(x => x.Nombre.ToUpper() == createSolicitudDTO.Zona.ToUpper());
            if (zonaEntity == null)
            {
                throw new BusinessException($"la {createSolicitudDTO.Zona} no existe");
            }

            SolicitudEntity nuevaSolicitud = new SolicitudEntity
            {
                Descripcion = createSolicitudDTO.Descripcion,
                ZonaId = zonaEntity.Id,
                TipoSolicitudId = tipoSolicitudEntity.Id,
                UsuarioId = usuarioId,
                EstadoSolicitudId=(int)EstadoSolicitudEnum.Pendiente,
            };

            await _unitOfWork.SolicitudRepository.AddAsync(nuevaSolicitud);
            await _unitOfWork.SaveChangesAsync();

            SolicitudDTO solicitudDTO = new SolicitudDTO
            {
                Id = nuevaSolicitud.Id,
                Descripcion = createSolicitudDTO.Descripcion,
                Zona = zonaEntity.Nombre,
                TipoSolicitud = tipoSolicitudEntity.Tipo,
                Usuario = $"{usuarioEntity.Nombre} {usuarioEntity.Apellido}",
                EstadoSolicitud = nameof(EstadoSolicitudEnum.Pendiente),
            };

            return solicitudDTO;
        }

        public IEnumerable<SolicitudDTO> ObtnerSolicitudesAprobacionUsuario(int usuarioId)
        {
            IEnumerable<int> zonasUsuario = _unitOfWork.UsuarioZonaRepository.Where(x => x.UsuarioId == usuarioId && x.Activo == true).Select(x => x.ZonaId);
            IEnumerable<int> tipoSolicitud = _unitOfWork.UsuarioTipoSolicitudRepository.Where(x => x.UsuarioId == usuarioId && x.Activo == true).Select(x => x.TipoSolicitudId);
            IEnumerable<SolicitudEntity> solicitudes = _unitOfWork.SolicitudRepository.ObtenerSolicitudesAprobacion(zonasUsuario, tipoSolicitud);

            return solicitudes.Select(x => new SolicitudDTO
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Zona = x.Zona.Nombre,
                TipoSolicitud = x.TipoSolicitud.Tipo,
                Usuario = $"{x.Usuario.Nombre} {x.Usuario.Apellido}",
                EstadoSolicitud = x.EstadoSolicitud.Estado,
            });
        }
    }
}
