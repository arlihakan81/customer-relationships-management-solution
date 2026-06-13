using CRM.Application.Dtos.Pipeline;

namespace CRM.Application.Interfaces
{
    public interface IPipelineService
    {
        Task<IEnumerable<PipelineDto>?> GetAllPipelinesAsync(int page = 1, int limit = 100, string? filter = null);
        Task<PipelineDto?> GetPipelineByIdAsync(Guid id);
        Task CreatePipelineAsync(CreatePipelineDto createPipelineDto);
        Task UpdatePipelineAsync(Guid id, UpdatePipelineDto updatePipelineDto);
        Task DeletePipelineAsync(Guid id);

    }
}
