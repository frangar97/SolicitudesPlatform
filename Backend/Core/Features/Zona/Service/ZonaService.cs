using Core.Features.Base;
using Core.Features.Zona.DTO;

namespace Core.Features.Zona.Service
{
    public class ZonaService : IZonaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ZonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ZonaDTO> GetAllZonas()
        {
            return _unitOfWork.ZonaRepository.GetAllSelect(x => new ZonaDTO { Id = x.Id, Nombre = x.Nombre });
        }
    }
}
