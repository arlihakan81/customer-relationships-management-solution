using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class LabelRepository(AppDbContext context) : Repository<Label>(context), ILabelRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Label>?> GetAllAsync(Expression<Func<Label, bool>>? expression = null)
        {
            return expression is null ? await _context.Labels.ToListAsync() :
                await _context.Labels.Where(expression).ToListAsync();
        }


    }
}
