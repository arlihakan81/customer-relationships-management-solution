using CRM.Application.Dtos.Customer;

namespace CRM.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>?> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateCustomerDto request);
        Task UpdateAsync(Guid id, UpdateCustomerDto request);
        Task DeleteAsync(Guid id);
    }
}
