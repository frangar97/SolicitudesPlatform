using Core.Exceptions;
using Core.Features.Base;
using Core.Features.TipoSolicitud.DTO;

namespace Core.Features.TipoSolicitud.Services
{
    public class TipoSolicitudService : ITipoSolicitudService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoSolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TipoSolicitudDTO> CreateTipoSolicitud(CreateTipoSolicitudDTO createTipoSolicitudDTO)
        {
            TipoSolicitudEntity? tipoSolicitudEntity = await _unitOfWork.TipoSolicitudRepository.FirstOrDefaultAsync(x=>x.Tipo.ToUpper()==createTipoSolicitudDTO.Tipo.ToUpper());
            if(tipoSolicitudEntity !=null)
            {
                throw new BusinessException($"el tipo de solicitud {createTipoSolicitudDTO.Tipo} ya existe");
            }

            TipoSolicitudEntity nuevoTipoSolicitud = new TipoSolicitudEntity { Tipo=createTipoSolicitudDTO.Tipo };
            await _unitOfWork.TipoSolicitudRepository.AddAsync(nuevoTipoSolicitud);
            await _unitOfWork.SaveChangesAsync();

            TipoSolicitudDTO tipoSolicitudDTO = new TipoSolicitudDTO { Id = nuevoTipoSolicitud.Id, Tipo = createTipoSolicitudDTO.Tipo };
            return tipoSolicitudDTO;
        }

        public IEnumerable<TipoSolicitudDTO> GetAllTiposSolicitud()
        {
            return _unitOfWork.TipoSolicitudRepository.GetAllSelect(x => new TipoSolicitudDTO { Id = x.Id, Tipo = x.Tipo });
        }
    }
}
