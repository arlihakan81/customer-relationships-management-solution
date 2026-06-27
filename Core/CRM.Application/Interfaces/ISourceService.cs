using CRM.Application.Dtos.Source;

namespace CRM.Application.Interfaces
{
    public interface ISourceService
    {
        Task<IEnumerable<SourceDto>?> GetAllSourcesAsync(int page = 1, int limit = 100, string? filter = null);
        Task<SourceDto?> GetSourceByIdAsync(Guid id);
        Task CreateSourceAsync(CreateSourceDto createSourceDto);
        Task UpdateSourceAsync(Guid id, UpdateSourceDto updateSourceDto);
        Task DeleteSourceAsync(Guid id);







    }
}
