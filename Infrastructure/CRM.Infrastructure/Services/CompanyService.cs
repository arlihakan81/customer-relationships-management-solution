using AutoMapper;
using CRM.Application.Dtos.Company;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class CompanyService(ICompanyRepository customerRepository, IMapper mapper) : ICompanyService
    {
        private readonly ICompanyRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(CreateCompanyDto request)
        {
            await _customerRepository.AddAsync(_mapper.Map<Company>(request));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CompanyDto>?> GetAllAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var customers = await _customerRepository.GetAllAsync(page, limit);
            if (filter is null)
            {
                return _mapper.Map<IEnumerable<CompanyDto>>(customers);
            }
            else
            {
                customers = await _customerRepository.GetAllAsync(page, limit, _ => _.Name.Contains(filter) || _.Email.Contains(filter) || _.StreetAddress!.Contains(filter));
            }
            return _mapper.Map<IEnumerable<CompanyDto>>(customers);
        }

        public async Task<CompanyDetailDto?> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CompanyDetailDto>(customer);
        }

        public async Task UpdateAsync(Guid id, UpdateAccountDto request)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            await _customerRepository.UpdateAsync(_mapper.Map(request, customer)!);
        }
    }
}
