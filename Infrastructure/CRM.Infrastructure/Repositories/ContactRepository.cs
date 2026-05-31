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

        public override async Task<IEnumerable<Contact>?> GetAllAsync(Expression<Func<Contact, bool>>? expression = null)
        {
            return expression is null ? await _context.Contacts.Include(c => c.Customer).ToListAsync() 
                : await _context.Contacts.Include(c => c.Customer).Where(expression).ToListAsync();
        }

        public override async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await _context.Contacts.Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id);
        }


    }
}
