using CRM.Domain.Entities.Commons;
using System.Linq.Expressions;

namespace CRM.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity<Guid>
    {
        Task<IEnumerable<T>?> GetAllAsync(int page = 1, int limit = 100, Expression<Func<T, bool>>? expression = null);
        Task<T?> GetByIdAsync(Guid id);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);


    }
}
