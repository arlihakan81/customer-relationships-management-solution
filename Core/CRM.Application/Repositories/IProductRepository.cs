using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>?> GetProductsByDealIdAsync(Guid dealId, int page = 1, int limit = 100);
    }
}
