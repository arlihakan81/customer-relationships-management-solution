using CRM.Application.Dtos.Stage;

namespace CRM.Application.Interfaces
{
    public interface IStageService
    {
        Task<IEnumerable<StageDto>?> GetStagesByPipelineIdAsync(Guid pipelineId);
        Task<StageDto?> GetStageByIdAsync(Guid stageId);
        Task<IEnumerable<StageDto>?> GetAllStagesAsync(int page = 1, int limit = 100, string? filter = null);

        Task CreateStageAsync(CreateStageDto createStageDto);
        Task UpdateStageAsync(Guid stageId, UpdateStageDto updateStageDto);
        Task DeleteStageAsync(Guid stageId);

    }
}
