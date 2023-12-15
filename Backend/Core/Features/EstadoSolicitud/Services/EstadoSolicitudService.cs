using Core.Features.Base;
using Core.Features.EstadoSolicitud.DTO;

namespace Core.Features.EstadoSolicitud.Services
{
    public class EstadoSolicitudService : IEstadoSolicitudService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoSolicitudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EstadoSolicitudDTO> GetAllEstadoSolicitud()
        {
            return _unitOfWork.EstadoSolicitudRepository.GetAllSelect(x => new EstadoSolicitudDTO { Id = x.Id, Estado = x.Estado });
        }
    }
}
