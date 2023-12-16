using Core.Features.Base;
using Core.Features.EstadoSolicitud;
using Core.Features.Genero;
using Core.Features.Solicitud;
using Core.Features.TipoSolicitud;
using Core.Features.TipoUsuario;
using Core.Features.Usuario;
using Core.Features.Zona;
using Persistence;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SolicitudesPlatformContext _context;

        public IBaseRepository<GeneroEntity>? generoRepository;

        public IBaseRepository<ZonaEntity>? zonaRepository;

        public IBaseRepository<TipoUsuarioEntity>? tipoUsuarioRepository;

        public IBaseRepository<TipoSolicitudEntity>? tipoSolicitudRepository;

        public IBaseRepository<EstadoSolicitudEntity>? estadoSolicitudRepository;

        public IBaseRepository<UsuarioEntity>? usuarioRepository;

        public IBaseRepository<SolicitudEntity>? solicitudRepository;

        public UnitOfWork(SolicitudesPlatformContext context)
        {
            _context = context;
        }

        public IBaseRepository<GeneroEntity> GeneroRepository
        {
            get
            {
                generoRepository ??= new BaseRepository<GeneroEntity>(_context);

                return generoRepository;
            }
        }

        public IBaseRepository<ZonaEntity> ZonaRepository
        {
            get
            {
                zonaRepository ??= new BaseRepository<ZonaEntity>(_context);

                return zonaRepository;
            }
        }

        public IBaseRepository<TipoUsuarioEntity> TipoUsuarioRepository
        {
            get
            {
                tipoUsuarioRepository ??= new BaseRepository<TipoUsuarioEntity>(_context);

                return tipoUsuarioRepository;
            }
        }

        public IBaseRepository<TipoSolicitudEntity> TipoSolicitudRepository
        {
            get
            {
                tipoSolicitudRepository ??= new BaseRepository<TipoSolicitudEntity>(_context);

                return tipoSolicitudRepository;
            }
        }

        public IBaseRepository<EstadoSolicitudEntity> EstadoSolicitudRepository
        {
            get
            {
                estadoSolicitudRepository ??= new BaseRepository<EstadoSolicitudEntity>(_context);

                return estadoSolicitudRepository;
            }
        }

        public IBaseRepository<UsuarioEntity> UsuarioRepository
        {
            get
            {
                usuarioRepository ??= new BaseRepository<UsuarioEntity>(_context);

                return usuarioRepository;
            }
        }

        public IBaseRepository<SolicitudEntity> SolicitudRepository
        {
            get
            {
                solicitudRepository ??= new BaseRepository<SolicitudEntity>(_context);

                return solicitudRepository;
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
