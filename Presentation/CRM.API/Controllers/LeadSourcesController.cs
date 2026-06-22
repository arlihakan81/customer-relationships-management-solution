using CRM.Application.Dtos.LeadSource;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadSourcesController(ILeadSourceService leadSourceService) : ControllerBase
    {
        private readonly ILeadSourceService _leadSourceService = leadSourceService;

        [HttpGet]
        public async Task<IActionResult> GetAllLeadSources([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var leadSources = await _leadSourceService.GetAllLeadSourcesAsync(page,limit,filter);
            if (leadSources is null)
            {
                return Ok(new List<LeadSourceDto>());
            }
            return Ok(leadSources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeadSourceById(Guid id)
        {
            var leadSource = await _leadSourceService.GetLeadSourceByIdAsync(id);
            if (leadSource is null)
            {
                return NotFound();
            }
            return Ok(leadSource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeadSource(CreateLeadSourceDto createLeadSourceDto)
        {
            await _leadSourceService.CreateLeadSourceAsync(createLeadSourceDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeadSource(Guid id, UpdateLeadSourceDto updateLeadSourceDto)
        {
            try
            {
                await _leadSourceService.UpdateLeadSourceAsync(id, updateLeadSourceDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadSource(Guid id)
        {
            try
            {
                await _leadSourceService.DeleteLeadSourceAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }



    }
}
