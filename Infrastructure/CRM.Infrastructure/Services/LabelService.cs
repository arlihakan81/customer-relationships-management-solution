using AutoMapper;
using CRM.Application.Dtos.Label;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class LabelService(ILabelRepository labelRepository, IMapper mapper) : ILabelService
    {
        private readonly ILabelRepository _labelRepository = labelRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateLabelAsync(CreateLabelDto createLabelDto)
        {
            await _labelRepository.AddAsync(_mapper.Map<Label>(createLabelDto));
        }

        public async Task DeleteLabelAsync(Guid id)
        {
            await _labelRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LabelDto>?> GetAllLabelsAsync()
        {
            var leadLabels = await _labelRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LabelDto>>(leadLabels);
        }

        public async Task<LabelDto?> GetLabelAsync(Guid id)
        {
            var leadLabel = await _labelRepository.GetByIdAsync(id);
            return _mapper.Map<LabelDto>(leadLabel);
        }

        public async Task UpdateLabelAsync(Guid id, UpdateLabelDto updateLeadLabelDto)
        {
            var leadLabel = await _labelRepository.GetByIdAsync(id)
                ?? throw new Exception("Label not found");
            await _labelRepository.UpdateAsync(_mapper.Map(updateLeadLabelDto, leadLabel));
        }
    }
}
