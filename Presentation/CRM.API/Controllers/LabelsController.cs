using CRM.Application.Dtos.Label;
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
    public class LabelsController(ILabelService leadLabelService) : ControllerBase
    {
        private readonly ILabelService _leadLabelService = leadLabelService;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var leadLabels = await _leadLabelService.GetAllLabelsAsync(page,limit,filter);
            
            return leadLabels is null || !leadLabels.Any() ? Ok(BaseResponse<LabelDto>.FailureResult(error: "No labels found")) : Ok(BaseResponse<LabelDto>.SuccessResult(leadLabels, page, limit));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var leadLabel = await _leadLabelService.GetLabelAsync(id);
            
            return leadLabel is null ? Ok(BaseResponse<LabelDto>.FailureResult(error: "No label found with provided id")) : Ok(BaseResponse<LabelDto>.SuccessResult(leadLabel));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLabelDto createLeadLabelDto)
        {
            await _leadLabelService.CreateLabelAsync(createLeadLabelDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateLabelDto updateLeadLabelDto)
        {
            try
            {
                await _leadLabelService.UpdateLabelAsync(id, updateLeadLabelDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _leadLabelService.DeleteLabelAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }









    }
}
