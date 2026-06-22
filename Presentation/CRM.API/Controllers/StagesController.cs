using CRM.Application.Dtos.Stage;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class StagesController(IStageService stageService) : ControllerBase
    {
        private readonly IStageService _stageService = stageService;

        [HttpGet("pipeline/{pipelineId}")]
        public async Task<IActionResult> GetStagesByPipelineIdAsync(Guid pipelineId)
        {
            var stages = await _stageService.GetStagesByPipelineIdAsync(pipelineId);
            return Ok(stages);
        }

        [HttpGet("{stageId}")]
        public async Task<IActionResult> GetStageByIdAsync(Guid stageId)
        {
            var stage = await _stageService.GetStageByIdAsync(stageId);
            if (stage is null)
            {
                return NotFound();
            }
            return Ok(stage);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStagesAsync([FromQuery]int page = 1, [FromQuery]int limit = 100, [FromQuery]string? filter = null)
        {
            var stages = await _stageService.GetAllStagesAsync(page, limit, filter);
            return Ok(stages);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStageAsync([FromBody] CreateStageDto createStageDto)
        {
            await _stageService.CreateStageAsync(createStageDto);
            return Ok();
        }

        [HttpPut]
        [Route("{stageId}")]
        public async Task<IActionResult> UpdateStageAsync(Guid stageId, [FromBody] UpdateStageDto updateStageDto)
        {
            await _stageService.UpdateStageAsync(stageId, updateStageDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("{stageId}")]
        public async Task<IActionResult> DeleteStageAsync(Guid stageId)
        {
            await _stageService.DeleteStageAsync(stageId);
            return NoContent();
        }




    }
}
