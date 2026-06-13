using CRM.Application.Dtos.Deal;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DealsController(IDealService dealService) : ControllerBase
    {
        private readonly IDealService _dealService = dealService;

        [HttpGet]
        public async Task<IActionResult> GetAllDeals([FromQuery]int page = 1, [FromQuery]int limit = 100, [FromQuery]string? filter = null)
        {
            var deals = await _dealService.GetAllDealsAsync(page, limit, filter);
            return Ok(deals);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDealById(Guid id)
        {
            var deal = await _dealService.GetDealByIdAsync(id);
            if (deal is null)
            {
                return NotFound();
            }
            return Ok(deal);
        }

        [HttpGet]
        [Route("stage/{stageId:guid}")]
        public async Task<IActionResult> GetDealsByStageId(Guid stageId)
        {
            var deals = await _dealService.GetDealsByStageIdAsync(stageId);
            return Ok(deals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeal(CreateDealDto createDealDto)
        {
            await _dealService.CreateDealAsync(createDealDto);
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDeal(Guid id, UpdateDealDto updateDealDto)
        {
            await _dealService.UpdateDealAsync(id, updateDealDto);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDeal(Guid id)
        {
            await _dealService.DeleteDealAsync(id);
            return Ok();
        }



    }
}
