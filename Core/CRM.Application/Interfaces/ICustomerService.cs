using CRM.Application.Dtos.Customer;

namespace CRM.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>?> GetAllAsync(int page = 1, int limit = 100, string? filter = null);
        Task<CustomerDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateCustomerDto request);
        Task UpdateAsync(Guid id, UpdateCustomerDto request);
        Task DeleteAsync(Guid id);
    }
}
