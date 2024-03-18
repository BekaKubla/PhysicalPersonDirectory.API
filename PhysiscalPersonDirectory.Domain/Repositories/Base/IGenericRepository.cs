using System.Linq.Expressions;

namespace PhysiscalPersonDirectory.Domain.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        Task<int> CountAsync(IQueryable<T> data, CancellationToken cancellationToken = default);
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> ToListAsync(IQueryable<T> data, CancellationToken cancellationToken = default);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        void Update(T entity);
    }
}
