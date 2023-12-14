using System.Linq.Expressions;

namespace Core.Features.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> FindByIdAsync(int id);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        void Update(T entity);
        IEnumerable<V> GetAllSelect<V>(Expression<Func<T, V>> expression);
    }
}
