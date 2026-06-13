using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class ContactRepository(AppDbContext context) : Repository<Contact>(context), IContactRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Contact>?> GetAllAsync(int page = 1, int limit = 100, Expression<Func<Contact, bool>>? expression = null)
        {
            return expression is null ? await _context.Contacts.Include(c => c.Customer).Skip((page-1)*limit).Take(limit).ToListAsync() 
                : await _context.Contacts.Include(c => c.Customer).Where(expression).Skip((page-1)*limit).Take(limit).ToListAsync();
        }

        public override async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await _context.Contacts.Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id);
        }


    }
}
