using CRM.Application.Dtos.Deal;
using CRM.Application.Dtos.Product;
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
    public class DealsController(IDealService dealService, IProductService productService) : ControllerBase
    {
        private readonly IDealService _dealService = dealService;
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAllDeals([FromQuery]int page = 1, [FromQuery]int limit = 100, [FromQuery]string? filter = null)
        {
            var deals = await _dealService.GetAllDealsAsync(page, limit, filter);
            return deals is null || !deals.Any() ? Ok(BaseResponse<DealDto>.FailureResult(error: "No deals found")) :
                Ok(BaseResponse<DealDto>.SuccessResult(deals, page, limit));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDealById(Guid id)
        {
            var deal = await _dealService.GetDealByIdAsync(id);
            return deal is null ? Ok(BaseResponse<DealDto>.FailureResult(error: "No deal found with the provided id")) :
                Ok(BaseResponse<DealDto>.SuccessResult(deal));
        }

        [HttpGet]
        [Route("stage/{stageId:guid}")]
        public async Task<IActionResult> GetDealsByStageId(Guid stageId, [FromQuery] int page = 1, [FromQuery] int limit = 100)
        {
            var deals = await _dealService.GetDealsByStageIdAsync(stageId);
            return deals is null || !deals.Any() ? Ok(BaseResponse<DealDto>.FailureResult(error: "No deals found for the provided stage id")) :
                Ok(BaseResponse<DealDto>.SuccessResult(deals, page, limit));
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByDealId(Guid dealId, [FromQuery] int page = 1, [FromQuery] int limit = 100)
        {
            var products = await _productService.GetProductsByDealIdAsync(dealId, page, limit);
            return products is null || !products.Any() ? Ok(BaseResponse<ProductDto>.FailureResult(error: "No products found for the provided deal id")) :
                Ok(BaseResponse<ProductDto>.SuccessResult(products, page, limit));
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
