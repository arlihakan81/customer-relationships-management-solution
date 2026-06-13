using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IDealRepository : IRepository<Deal>
    {
        Task<IEnumerable<Deal>?> GetDealsByStageIdAsync(Guid stageId);
    }
}
