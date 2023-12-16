using Core.Features.EstadoSolicitud;
using Core.Features.Genero;
using Core.Features.Solicitud;
using Core.Features.TipoSolicitud;
using Core.Features.TipoUsuario;
using Core.Features.Usuario;
using Core.Features.UsuarioTipoSolicitud;
using Core.Features.UsuarioZona;
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
        public IBaseRepository<UsuarioZonaEntity> UsuarioZonaRepository { get; }
        public IBaseRepository<UsuarioTipoSolicitudEntity> UsuarioTipoSolicitudRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public ISolicitudRepository SolicitudRepository { get; }
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
