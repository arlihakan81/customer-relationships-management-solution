using CRM.Application.Dtos.Lead;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadsController(ILeadService leadService) : ControllerBase
    {
        private readonly ILeadService _leadService = leadService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leads = await _leadService.GetAllLeadsAsync();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var lead = await _leadService.GetLeadByIdAsync(id);
            if (lead == null)
                return NotFound();
            return Ok(lead);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeadDto createLeadDto)
        {
            await _leadService.CreateLeadAsync(createLeadDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateLeadDto updateLeadDto)
        {
            await _leadService.UpdateLeadAsync(id, updateLeadDto);
            return NoContent();
        }

        [HttpPatch("{id}/convert")]
        public async Task<IActionResult> Convert(Guid id)
        {
            await _leadService.ConvertLeadAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _leadService.DeleteLeadAsync(id);
            return NoContent();
        }


    }
}
