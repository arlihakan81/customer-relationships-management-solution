using AutoMapper;
using CRM.Application.Dtos.Pipeline;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;

namespace CRM.Infrastructure.Services
{
    public class PipelineService(IPipelineRepository pipelineRepository, IMapper mapper) : IPipelineService
    {
        private readonly IPipelineRepository _pipelineRepository = pipelineRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreatePipelineAsync(CreatePipelineDto createPipelineDto)
        {
            await _pipelineRepository.AddAsync(_mapper.Map<Domain.Entities.Pipeline>(createPipelineDto));
        }

        public async Task DeletePipelineAsync(Guid id)
        {
            await _pipelineRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PipelineDto>?> GetAllPipelinesAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var pipelines = await _pipelineRepository.GetAllAsync(page, limit);
            if(filter is null)
            {
                return _mapper.Map<IEnumerable<PipelineDto>>(pipelines);
            }
            else
            {
                pipelines = await _pipelineRepository.GetAllAsync(page, limit, _ => _.Name.Contains(filter));
            }
            return _mapper.Map<IEnumerable<PipelineDto>>(pipelines);
        }

        public async Task<PipelineDto?> GetPipelineByIdAsync(Guid id)
        {
            var pipeline = await _pipelineRepository.GetByIdAsync(id);
            return _mapper.Map<PipelineDto>(pipeline);
        }

        public async Task UpdatePipelineAsync(Guid id, UpdatePipelineDto updatePipelineDto)
        {
            var pipeline = await _pipelineRepository.GetByIdAsync(id);
            if (pipeline is null)
            {
                throw new Exception("Pipeline not found");
            }            
            await _pipelineRepository.UpdateAsync(_mapper.Map(updatePipelineDto, pipeline));
        }
    }
}
