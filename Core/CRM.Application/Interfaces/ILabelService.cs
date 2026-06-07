using CRM.Application.Dtos.Label;

namespace CRM.Application.Interfaces
{
    public interface ILabelService
    {
        Task<IEnumerable<LabelDto>?> GetAllLabelsAsync();
        Task<LabelDto?> GetLabelAsync(Guid id);
        Task CreateLabelAsync(CreateLabelDto createLabelDto);
        Task UpdateLabelAsync(Guid id, UpdateLabelDto updateLabelDto);
        Task DeleteLabelAsync(Guid id);
    }
}
