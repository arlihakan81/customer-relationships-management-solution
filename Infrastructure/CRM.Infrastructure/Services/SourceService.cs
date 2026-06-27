using AutoMapper;
using CRM.Application.Dtos.Source;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class SourceService(ISourceRepository sourceRepository, IMapper mapper) : ISourceService
    {
        private readonly ISourceRepository _sourceRepository = sourceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateSourceAsync(CreateSourceDto createSourceDto)
        {
            await _sourceRepository.AddAsync(_mapper.Map<Source>(createSourceDto));
        }

        public async Task DeleteSourceAsync(Guid id)
        {
            await _sourceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SourceDto>?> GetAllSourcesAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var sources = await _sourceRepository.GetAllAsync(page,limit);
            if(filter is null)
            {
                return _mapper.Map<IEnumerable<SourceDto>>(sources);
            }
            else
            {
                sources = await _sourceRepository.GetAllAsync(page, limit, ls => ls.Name.Contains(filter));
            }
            return _mapper.Map<IEnumerable<SourceDto>>(sources);
        }

        public async Task<SourceDto?> GetSourceByIdAsync(Guid id)
        {
            var source = await _sourceRepository.GetByIdAsync(id);
            return _mapper.Map<SourceDto>(source);
        }

        public async Task UpdateSourceAsync(Guid id, UpdateSourceDto updateSourceDto)
        {
            var source = await _sourceRepository.GetByIdAsync(id);
            if (source is null)
            {
                throw new Exception("Lead source not found");
            }
            await _sourceRepository.UpdateAsync(_mapper.Map(updateSourceDto, source));
        }
    }
}
