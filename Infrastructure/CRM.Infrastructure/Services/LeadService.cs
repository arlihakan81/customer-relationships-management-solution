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

        public async Task<IEnumerable<LeadDto>?> GetAllLeadsAsync()
        {
            var leads = await _leadRepository.GetAllAsync();
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
