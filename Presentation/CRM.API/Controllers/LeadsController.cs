using CRM.Application.Dtos.Lead;
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
    public class LeadsController(ILeadService leadService) : ControllerBase
    {
        private readonly ILeadService _leadService = leadService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var leads = await _leadService.GetAllLeadsAsync(page,limit,filter);
            return leads is null || !leads.Any() ? Ok(BaseResponse<LeadDto>.FailureResult(error: "No leads found")) : Ok(BaseResponse<LeadDto>.SuccessResult(leads, page, limit));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var lead = await _leadService.GetLeadByIdAsync(id);
            return lead is null ? Ok(BaseResponse<LeadDto>.FailureResult(error: "No lead found with provided id")) : Ok(BaseResponse<LeadDto>.SuccessResult(lead));
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
