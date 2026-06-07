using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class LeadRepository(AppDbContext context) : Repository<Lead>(context), ILeadRepository
    {
        private readonly AppDbContext _context = context;

        public override async Task<IEnumerable<Lead>?> GetAllAsync(Expression<Func<Lead, bool>>? expression = null)
        {
            return expression is null ? await _context.Leads.Include(l => l.Source).Include(l => l.Labels).ToListAsync() :
                await _context.Leads.Include(l => l.Source).Include(l => l.Labels).Where(expression).ToListAsync();
        }

        public override async Task<Lead?> GetByIdAsync(Guid id)
        {
            return await _context.Leads.Include(l => l.Source).Include(l => l.Labels).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task ConvertAsync(Guid leadId)
        {
            var lead = _context.Leads.FirstOrDefault(l => l.Id == leadId) ??  
                throw new Exception("Lead not found");
            lead.IsConverted = true;
            _context.Customers.Add(new Customer
            {
                Name = lead.Company,
                Email = lead.Email,
                Phone = lead.Phone,
                Address = lead.Address,
                Contacts = [
                    new Contact {
                        Name = lead.Name,
                        Email = lead.Email,
                        Phone = lead.Phone,
                        Address = lead.Address
                    }
                ]
            });
            await _context.SaveChangesAsync();
        }
    }
}
