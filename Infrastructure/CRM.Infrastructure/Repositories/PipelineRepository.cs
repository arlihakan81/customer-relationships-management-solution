using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class PipelineRepository(AppDbContext context) : Repository<Pipeline>(context), IPipelineRepository
    {
    }
}
