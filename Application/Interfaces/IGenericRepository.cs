// practice_0502025.Application.Interfaces/IGenericRepository.cs

using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq; // For IOrderedQueryable

namespace practice_0502025.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity?> GetByIdAsync(int id,
            params Expression<Func<TEntity, object>>[] includes);

        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        // REMOVED: Task SaveChangesAsync(); // This is now handled by IUnitOfWork

        // Retaining advanced querying methods from previous suggestion (optional, but good practice)
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            IEnumerable<Expression<Func<TEntity, object>>>? includes = null,
            bool disableTracking = false);

        Task<IEnumerable<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            IEnumerable<Expression<Func<TEntity, object>>>? includes = null,
            bool disableTracking = false);

        Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}