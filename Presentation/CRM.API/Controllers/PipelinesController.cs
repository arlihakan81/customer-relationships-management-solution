using CRM.Application.Dtos.Pipeline;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PipelinesController(IPipelineService pipelineService, IStageService stageService) : ControllerBase
    {
        private readonly IPipelineService _pipelineService = pipelineService;
        private readonly IStageService _stageService = stageService;

        [HttpGet]
        public async Task<IActionResult> GetAllPipelines([FromQuery] int page = 1, [FromQuery]int limit = 100, [FromQuery]string? filter = null)
        {
            var pipelines = await _pipelineService.GetAllPipelinesAsync(page, limit, filter);
            return Ok(pipelines);
        }

        [HttpGet]
        [Route("{id}/stages")]
        public async Task<IActionResult> GetStagesByPipelineId(Guid id)
        {
            var stages = await _stageService.GetStagesByPipelineIdAsync(id);
            return Ok(stages);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePipeline(CreatePipelineDto createPipelineDto)
        {
            await _pipelineService.CreatePipelineAsync(createPipelineDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPipelineById(Guid id)
        {
            var pipeline = await _pipelineService.GetPipelineByIdAsync(id);
            if (pipeline is null)
            {
                return NotFound();
            }
            return Ok(pipeline);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePipeline(Guid id, UpdatePipelineDto updatePipelineDto)
        {
            try
            {
                await _pipelineService.UpdatePipelineAsync(id, updatePipelineDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePipeline(Guid id)
        {
            await _pipelineService.DeletePipelineAsync(id);
            return Ok();
        }




    }
}
