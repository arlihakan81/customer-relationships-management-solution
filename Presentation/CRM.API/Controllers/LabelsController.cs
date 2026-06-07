using CRM.Application.Dtos.Label;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LabelsController(ILabelService leadLabelService) : ControllerBase
    {
        private readonly ILabelService _leadLabelService = leadLabelService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leadLabels = await _leadLabelService.GetAllLabelsAsync();
            if (leadLabels is null)
            {
                return Ok(new List<LabelDto>());
            }
            return Ok(leadLabels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var leadLabel = await _leadLabelService.GetLabelAsync(id);
            if (leadLabel is null)
            {
                return NotFound();
            }
            return Ok(leadLabel);
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
