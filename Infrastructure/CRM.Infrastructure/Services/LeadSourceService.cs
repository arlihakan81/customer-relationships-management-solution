using AutoMapper;
using CRM.Application.Dtos.LeadSource;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class LeadSourceService(ILeadSourceRepository leadSourceRepository, IMapper mapper) : ILeadSourceService
    {
        private readonly ILeadSourceRepository _leadSourceRepository = leadSourceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateLeadSourceAsync(CreateLeadSourceDto createLeadSourceDto)
        {
            await _leadSourceRepository.AddAsync(_mapper.Map<LeadSource>(createLeadSourceDto));
        }

        public async Task DeleteLeadSourceAsync(Guid id)
        {
            await _leadSourceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LeadSourceDto>?> GetAllLeadSourcesAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var leadSources = await _leadSourceRepository.GetAllAsync(page,limit);
            if(filter is null)
            {
                return _mapper.Map<IEnumerable<LeadSourceDto>>(leadSources);
            }
            else
            {
                leadSources = await _leadSourceRepository.GetAllAsync(page, limit, ls => ls.Name.Contains(filter));
            }
            return _mapper.Map<IEnumerable<LeadSourceDto>>(leadSources);
        }

        public async Task<LeadSourceDto?> GetLeadSourceByIdAsync(Guid id)
        {
            var leadSource = await _leadSourceRepository.GetByIdAsync(id);
            return _mapper.Map<LeadSourceDto>(leadSource);
        }

        public async Task UpdateLeadSourceAsync(Guid id, UpdateLeadSourceDto updateLeadSourceDto)
        {
            var leadSource = await _leadSourceRepository.GetByIdAsync(id);
            if (leadSource is null)
            {
                throw new Exception("Lead source not found");
            }
            await _leadSourceRepository.UpdateAsync(_mapper.Map(updateLeadSourceDto, leadSource));
        }
    }
}
