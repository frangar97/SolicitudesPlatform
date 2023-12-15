using Core.Features.EstadoSolicitud;
using Core.Features.Genero;
using Core.Features.TipoSolicitud;
using Core.Features.TipoUsuario;
using Core.Features.Usuario;
using Core.Features.Zona;

namespace Core.Features.Base
{
    public interface IUnitOfWork:IDisposable
    {
        public IBaseRepository<GeneroEntity> GeneroRepository { get; }
        public IBaseRepository<ZonaEntity> ZonaRepository { get; }
        public IBaseRepository<TipoUsuarioEntity> TipoUsuarioRepository { get; }
        public IBaseRepository<TipoSolicitudEntity> TipoSolicitudRepository { get; }
        public IBaseRepository<EstadoSolicitudEntity> EstadoSolicitudRepository { get; }
        public IBaseRepository<UsuarioEntity> UsuarioRepository { get; }
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
