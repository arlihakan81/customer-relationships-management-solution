using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class SourceRepository(AppDbContext context) : Repository<Source>(context), ISourceRepository
    {
        private readonly AppDbContext _context = context;



    }
}
