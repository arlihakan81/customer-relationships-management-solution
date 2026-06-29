using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class CompanyRepository(AppDbContext context) : Repository<Company>(context), ICompanyRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Company>?> GetAllAsync(int page = 1, int limit = 100, Expression<Func<Company, bool>>? expression = null)
        {
            return expression is null ? await _context.Companies.Include(c => c.Contacts).Include(c => c.Deals).Skip((page - 1) * limit).Take(limit).ToListAsync() :
                await _context.Companies.Include(c => c.Contacts).Include(c => c.Deals).Where(expression).Skip((page - 1) * limit).Take(limit).ToListAsync();
        }


    }
}
