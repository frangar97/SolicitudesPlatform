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

        public IEnumerable<ZonaDTO> ZonaAsociadoUsuario(int usuarioId)
        {
            IEnumerable<int> usuarioZonaId = _unitOfWork.UsuarioZonaRepository.Where(x => x.UsuarioId == usuarioId && x.Activo == true).Select(x => x.ZonaId);
            IEnumerable<ZonaDTO> zonaDTOs = _unitOfWork.ZonaRepository.Where(x => usuarioZonaId.Contains(x.Id)).Select(x => new ZonaDTO { Id = x.Id, Nombre = x.Nombre });
            return zonaDTOs;
        }

        public IEnumerable<ZonaDTO> ZonaNoAsociadoUsuario(int usuarioId)
        {
            IEnumerable<int> usuarioZonaId = _unitOfWork.UsuarioZonaRepository.Where(x => x.UsuarioId == usuarioId && x.Activo == true).Select(x => x.ZonaId);
            IEnumerable<ZonaDTO> zonaDTOs = _unitOfWork.ZonaRepository.Where(x => !usuarioZonaId.Contains(x.Id)).Select(x => new ZonaDTO { Id = x.Id, Nombre = x.Nombre });
            return zonaDTOs;
        }
    }
}
