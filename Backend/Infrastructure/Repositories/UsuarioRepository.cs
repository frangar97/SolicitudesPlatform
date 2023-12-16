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

        public IEnumerable<UsuarioEntity> ObtenerUsuarios()
        {
            return _entities
                .Include(x => x.Genero)
                .Include(x => x.TipoUsuario)
                .AsEnumerable();

        }
    }
}
