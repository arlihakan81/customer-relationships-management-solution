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
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var products = await _productService.GetAllProductsAsync(page, limit, filter);
            if (products is null || !products.Any())
            {
                return Ok(BaseResponse<ProductDto>.FailureResult(error: "No items found", message: "No Items "));
            }
            return Ok(BaseResponse<ProductDto>.SuccessResult(products, page, limit, message: "Items retrieved successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null)
            {
                return Ok(BaseResponse<ProductDto>.FailureResult(error: "No item by provided item id"));
            }
            return Ok(BaseResponse<ProductDto>.SuccessResult(data: product));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            try
            {
                await _productService.UpdateProductAsync(id, updateProductDto);
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
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
