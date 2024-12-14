using System.Linq.Expressions;

namespace AenEnterprise.DataAccess.RepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> SearchAsync(Func<T, bool> predicate);
        Task<T> GetByStringAsync(Expression<Func<T, bool>> predicate);
    }
}
