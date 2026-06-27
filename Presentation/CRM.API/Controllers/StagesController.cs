using CRM.Application.Dtos.Stage;
using CRM.Application.Interfaces;
using CRM.Application.Responses;
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

        [HttpGet]
        public async Task<IActionResult> GetStages([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var stages = await _stageService.GetAllStagesAsync(page, limit, filter);
            if(stages is null || !stages.Any())
            {
                return Ok(BaseResponse<StageDto>.FailureResult(error: "No stages found"));
            }
            return Ok(BaseResponse<StageDto>.SuccessResult(stages, page, limit, message: "Items retrieved successfully"));
        }

        [HttpGet("pipeline/{pipelineId}")]
        public async Task<IActionResult> GetStagesByPipelineIdAsync(Guid pipelineId)
        {
            var stages = await _stageService.GetStagesByPipelineIdAsync(pipelineId);
            if(stages is null || !stages.Any())
            {
                return Ok(BaseResponse<StageDto>.FailureResult(error: "No stages by provided pipeline id"));
            }
            return Ok(BaseResponse<StageDto>.SuccessResult(stages,1,20, message: "Stages by provided pipeline id retrieved successfully"));
        }

        [HttpGet("{stageId}")]
        public async Task<IActionResult> GetStageByIdAsync(Guid stageId)
        {
            var stage = await _stageService.GetStageByIdAsync(stageId);
            if (stage is null)
            {
                return Ok(BaseResponse<StageDto>.FailureResult(error: "", message: "No stage found by provided stage id"));
            }
            return Ok(BaseResponse<StageDto>.SuccessResult(stage, message: "Stage by provided stage id retrieved successfully"));
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
