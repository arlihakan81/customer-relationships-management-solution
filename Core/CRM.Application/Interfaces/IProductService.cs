using CRM.Application.Dtos.Product;

namespace CRM.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>?> GetAllProductsAsync(int page = 1, int limit = 100, string? filter = null);
        Task<IEnumerable<ProductDto>?> GetProductsByDealIdAsync(Guid dealId, int page = 1, int limit = 100);
        Task<ProductDto?> GetProductByIdAsync(Guid productId);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(Guid productId, UpdateProductDto updateProductDto);
        Task DeleteProductAsync(Guid productId);
    }
}
