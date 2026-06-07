using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class LeadSourceRepository(AppDbContext context) : Repository<LeadSource>(context), ILeadSourceRepository
    {
        private readonly AppDbContext _context = context;



    }
}
