using Core.Features.Base;
using Core.Features.TipoUsuario.DTO;

namespace Core.Features.TipoUsuario.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TipoUsuarioDTO> GetAllTiposUsuario()
        {
            return _unitOfWork.TipoUsuarioRepository.GetAllSelect(x => new TipoUsuarioDTO { Id = x.Id, Tipo = x.Tipo });
        }
    }
}
