using Core.Features.Base;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected SolicitudesPlatformContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(SolicitudesPlatformContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T? entity = await FindByIdAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _entities.FirstOrDefaultAsync(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public IEnumerable<V> GetAllSelect<V>(Expression<Func<T, V>> expression)
        {
            return _entities.Select(expression)
                .AsEnumerable();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression);
        }
    }
}
