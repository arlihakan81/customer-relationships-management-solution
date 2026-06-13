using CRM.Application.Dtos.Deal;

namespace CRM.Application.Interfaces
{
    public interface IDealService
    {
        Task<IEnumerable<DealDto>?> GetAllDealsAsync(int page = 1, int limit = 100, string? filter = null);
        Task<DealDto?> GetDealByIdAsync(Guid id);

        Task CreateDealAsync(CreateDealDto createDealDto);
        Task DeleteDealAsync(Guid id);
        Task UpdateDealAsync(Guid id, UpdateDealDto updateDealDto);

        Task<IEnumerable<DealDto>?> GetDealsByStageIdAsync(Guid stageId);


    }
}
