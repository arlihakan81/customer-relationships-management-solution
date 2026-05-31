using AutoMapper;
using CRM.Application.Dtos.Customer;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(CreateCustomerDto request)
        {
            await _customerRepository.AddAsync(_mapper.Map<Customer>(request));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>?> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task UpdateAsync(Guid id, UpdateCustomerDto request)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            await _customerRepository.UpdateAsync(_mapper.Map(request, customer)!);
        }
    }
}
