using CRM.Application.Repositories;
using CRM.Domain.Entities.Commons;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : BaseEntity<Guid>
    {
        private readonly AppDbContext _context = context;

        public virtual async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            entity!.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>?> GetAllAsync(int page = 1, int limit = 100, Expression<Func<T, bool>>? expression = null)
        {
            return expression is null ? await _context.Set<T>().Skip((page - 1)*limit).Take(limit).ToListAsync() : 
                await _context.Set<T>().Where(expression).Skip((page - 1)*limit).Take(limit).ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
