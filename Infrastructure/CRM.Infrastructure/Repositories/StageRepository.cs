using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class StageRepository(AppDbContext context) : Repository<Stage>(context), IStageRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Stage>?> GetStagesByPipelineIdAsync(Guid pipelineId)
        {
            return await _context.Stages.Where(s => s.PipelineId == pipelineId).ToListAsync();
        }
    }
}
