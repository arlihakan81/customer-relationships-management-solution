using CRM.Application.Dtos.Lead;

namespace CRM.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadDto>?> GetAllLeadsAsync(int page = 1, int limit = 100, string? filter = null);
        Task<LeadDto?> GetLeadByIdAsync(Guid leadId);

        Task CreateLeadAsync(CreateLeadDto createLeadDto);
        Task UpdateLeadAsync(Guid leadId, UpdateLeadDto updateLeadDto);
        Task DeleteLeadAsync(Guid leadId);
        Task ConvertLeadAsync(Guid leadId);
    }
}
