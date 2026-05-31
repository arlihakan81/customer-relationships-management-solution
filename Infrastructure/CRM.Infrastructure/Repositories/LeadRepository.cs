using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class LeadRepository(AppDbContext context) : Repository<Lead>(context), ILeadRepository
    {
        private readonly AppDbContext _context = context;

        public async Task ConvertAsync(Guid leadId)
        {
            var lead = _context.Leads.FirstOrDefault(l => l.Id == leadId) ??  
                throw new Exception("Lead not found");
            lead.IsConverted = true;
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }
    }
}
