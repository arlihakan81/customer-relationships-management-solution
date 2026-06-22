using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CRM.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Product>?> GetProductsByDealIdAsync(Guid dealId, int page = 1, int limit = 100)
        {
            return await _context.Products.Where(p => p.DealItems!.Any(dli => dli.DealId == dealId)).Skip((page -1)*limit).Take(limit).ToListAsync();
        }
    }
}
