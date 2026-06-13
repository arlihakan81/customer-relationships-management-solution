using AutoMapper;
using CRM.Application.Dtos.Stage;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;

namespace CRM.Infrastructure.Services
{
    public class StageService(IStageRepository stageRepository, IMapper mapper) : IStageService
    {
        private readonly IStageRepository _stageRepository = stageRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateStageAsync(CreateStageDto createStageDto)
        {
            await _stageRepository.AddAsync(_mapper.Map<Domain.Entities.Stage>(createStageDto));
        }

        public async Task DeleteStageAsync(Guid stageId)
        {
            await _stageRepository.DeleteAsync(stageId);
        }

        public async Task<IEnumerable<StageDto>?> GetAllStagesAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var stages = await _stageRepository.GetAllAsync(page, limit);
            if(filter is null)
            {
                return _mapper.Map<IEnumerable<StageDto>>(stages);
            }
            else
            {
                stages = await _stageRepository.GetAllAsync(page,limit, _ => _.Name.Contains(filter) || _.Description!.Contains(filter));
            }
            return _mapper.Map<IEnumerable<StageDto>>(stages);
        }

        public async Task<StageDto?> GetStageByIdAsync(Guid stageId)
        {
            var stage = await _stageRepository.GetByIdAsync(stageId);
            return _mapper.Map<StageDto>(stage);
        }

        public async Task<IEnumerable<StageDto>?> GetStagesByPipelineIdAsync(Guid pipelineId)
        {
            var stages = await _stageRepository.GetStagesByPipelineIdAsync(pipelineId);
            return _mapper.Map<IEnumerable<StageDto>>(stages);
        }

        public async Task UpdateStageAsync(Guid stageId, UpdateStageDto updateStageDto)
        {
            var stage = await _stageRepository.GetByIdAsync(stageId)
                        ?? throw new Exception($"Stage with id {stageId} not found.");
            await _stageRepository.UpdateAsync(_mapper.Map(updateStageDto, stage));
        }
    }
}
