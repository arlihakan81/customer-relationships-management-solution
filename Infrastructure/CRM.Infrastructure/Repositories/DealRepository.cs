using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class DealRepository(AppDbContext context) : Repository<Deal>(context), IDealRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Deal>?> GetAllAsync(int page = 1, int limit = 100, Expression<Func<Deal, bool>>? expression = null)
        {
            return expression is null ? await _context.Deals.Include(a => a.Stage).Include(a => a.Items).Skip((page - 1) * limit).Take(limit).ToListAsync() : await _context.Deals.Include(a => a.Stage).Include(a => a.Items).Where(expression).Skip((page - 1) * limit).Take(limit).ToListAsync();
        }

        public async Task<IEnumerable<Deal>?> GetDealsByStageIdAsync(Guid stageId)
        {
            return await _context.Deals.Where(d => d.StageId == stageId).ToListAsync();
        }
    }
}
