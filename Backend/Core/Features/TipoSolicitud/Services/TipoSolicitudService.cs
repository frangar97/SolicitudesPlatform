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
        public IEnumerable<TipoSolicitudDTO> GetAllTiposSolicitud()
        {
            return _unitOfWork.TipoSolicitudRepository.GetAllSelect(x => new TipoSolicitudDTO { Id = x.Id, Tipo = x.Tipo });
        }
    }
}
