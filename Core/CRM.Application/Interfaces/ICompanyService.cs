using CRM.Application.Dtos.Company;

namespace CRM.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>?> GetAllAsync(int page = 1, int limit = 100, string? filter = null);
        Task<CompanyDetailDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateCompanyDto request);
        Task UpdateAsync(Guid id, UpdateAccountDto request);
        Task DeleteAsync(Guid id);
    }
}
