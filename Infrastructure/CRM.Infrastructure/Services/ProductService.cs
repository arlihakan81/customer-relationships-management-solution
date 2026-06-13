using AutoMapper;
using CRM.Application.Dtos.Product;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;

namespace CRM.Infrastructure.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productRepository.AddAsync(_mapper.Map<Domain.Entities.Product>(createProductDto));
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<IEnumerable<ProductDto>?> GetAllProductsAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var products = await _productRepository.GetAllAsync(page, limit);
            if(filter is null)
            {
                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            else
            {
                products = await _productRepository.GetAllAsync(page, limit, p => p.Name.Contains(filter) || p.Description!.Contains(filter) || p.Category!.Contains(filter));
            }
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(Guid productId, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            await _productRepository.UpdateAsync(_mapper.Map(updateProductDto, product)!);
        }
    }
}
