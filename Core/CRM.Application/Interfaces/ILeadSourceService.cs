using CRM.Application.Dtos.LeadSource;

namespace CRM.Application.Interfaces
{
    public interface ILeadSourceService
    {
        Task<IEnumerable<LeadSourceDto>?> GetAllLeadSourcesAsync(int page = 1, int limit = 100, string? filter = null);
        Task<LeadSourceDto?> GetLeadSourceByIdAsync(Guid id);
        Task CreateLeadSourceAsync(CreateLeadSourceDto createLeadSourceDto);
        Task UpdateLeadSourceAsync(Guid id, UpdateLeadSourceDto updateLeadSourceDto);
        Task DeleteLeadSourceAsync(Guid id);







    }
}
