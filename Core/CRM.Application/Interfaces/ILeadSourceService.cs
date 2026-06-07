using CRM.Application.Dtos.LeadSource;

namespace CRM.Application.Interfaces
{
    public interface ILeadSourceService
    {
        Task<IEnumerable<LeadSourceDto>?> GetAllLeadSourcesAsync();
        Task<LeadSourceDto?> GetLeadSourceByIdAsync(Guid id);
        Task CreateLeadSourceAsync(CreateLeadSourceDto createLeadSourceDto);
        Task UpdateLeadSourceAsync(Guid id, UpdateLeadSourceDto updateLeadSourceDto);
        Task DeleteLeadSourceAsync(Guid id);







    }
}
