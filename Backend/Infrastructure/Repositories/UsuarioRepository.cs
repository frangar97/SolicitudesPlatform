using Core.Features.Usuario;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(SolicitudesPlatformContext context) : base(context)
        {
        }

        public UsuarioEntity? ObtenerUsuario(int usuarioId)
        {
            return _entities
                .Include(x => x.Genero)
                .Include(x => x.TipoUsuario)
                .FirstOrDefault(x => x.Id == usuarioId);
        }

        public IEnumerable<UsuarioEntity> ObtenerUsuarios()
        {
            return _entities
                .Include(x => x.Genero)
                .Include(x => x.TipoUsuario)
                .AsEnumerable();

        }
    }
}
