using CRM.Application.Dtos.Source;
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
    public class SourcesController(ISourceService sourceService) : ControllerBase
    {
        private readonly ISourceService _sourceService = sourceService;

        [HttpGet]
        public async Task<IActionResult> GetAllSources([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var sources = await _sourceService.GetAllSourcesAsync(page,limit,filter);
            if (sources is null || !sources.Any())
            {
                return Ok(BaseResponse<SourceDto>.FailureResult(error: "No sources found"));
            }
            return Ok(BaseResponse<SourceDto>.SuccessResult(sources,page,limit,message: "Data retrieved successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSourceById(Guid id)
        {
            var source = await _sourceService.GetSourceByIdAsync(id);
            if (source is null)
            {
                return Ok(BaseResponse<SourceDto>.FailureResult(error: "No source by provided id"));
            }
            return Ok(BaseResponse<SourceDto>.SuccessResult(source, message: "Data retrieved successfully"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSource(CreateSourceDto createSourceDto)
        {
            await _sourceService.CreateSourceAsync(createSourceDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSource(Guid id, UpdateSourceDto updateSourceDto)
        {
            await _sourceService.UpdateSourceAsync(id, updateSourceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSource(Guid id)
        {
            try
            {
                await _sourceService.DeleteSourceAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
