using AutoMapper;
using CRM.Application.Dtos.Lead;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class LeadService(ILeadRepository leadRepository, IMapper mapper) : ILeadService
    {
        private readonly ILeadRepository _leadRepository = leadRepository;
        private readonly IMapper _mapper = mapper;

        public async Task ConvertLeadAsync(Guid leadId)
        {
            await _leadRepository.ConvertAsync(leadId);
        }

        public async Task CreateLeadAsync(CreateLeadDto createLeadDto)
        {
            await _leadRepository.AddAsync(_mapper.Map<Lead>(createLeadDto));
        }

        public async Task DeleteLeadAsync(Guid leadId)
        {
            await _leadRepository.DeleteAsync(leadId);
        }

        public async Task<IEnumerable<LeadDto>?> GetAllLeadsAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var leads = await _leadRepository.GetAllAsync(page, limit);
            if (filter is null)
            {
                return _mapper.Map<IEnumerable<LeadDto>>(leads);
            }
            else
            {
                leads = await _leadRepository.GetAllAsync(page, limit, l => l.Name.Contains(filter!) || l.Email.Contains(filter!) || l.Phone.Contains(filter!));
            }
            return _mapper.Map<IEnumerable<LeadDto>>(leads);
        }

        public async Task<LeadDto?> GetLeadByIdAsync(Guid leadId)
        {
            var lead = await _leadRepository.GetByIdAsync(leadId);
            return _mapper.Map<LeadDto>(lead);
        }

        public async Task UpdateLeadAsync(Guid leadId, UpdateLeadDto updateLeadDto)
        {
            var lead = await _leadRepository.GetByIdAsync(leadId);
            await _leadRepository.UpdateAsync(_mapper.Map(updateLeadDto, lead)!);
        }
    }
}
