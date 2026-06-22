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

        public override async Task<IEnumerable<Lead>?> GetAllAsync(int page = 1, int limit = 100, Expression<Func<Lead, bool>>? expression = null)
        {
            return expression is null ? await _context.Leads.Include(l => l.Source).Include(l => l.Labels).Skip((page - 1)*limit).Take(limit).ToListAsync() :
                await _context.Leads.Include(l => l.Source).Include(l => l.Labels).Where(expression).Skip((page - 1)*limit).Take(limit).ToListAsync();
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
            _context.Companies.Add(new Company
            {
                Name = lead.Company,
                Email = lead.Email,
                Contacts = [
                    new Contact {
                        FirstName = lead.Name,
                        LastName = lead.Name,
                        Email = lead.Email,
                        Phone = lead.Phone,
                        StreetAddress = lead.Address
                    }
                ]
            });
            await _context.SaveChangesAsync();
        }
    }
}
