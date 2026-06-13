using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IStageRepository : IRepository<Stage>
    {
        Task<IEnumerable<Stage>?> GetStagesByPipelineIdAsync(Guid pipelineId);
    }
}
