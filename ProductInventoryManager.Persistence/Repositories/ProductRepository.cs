using Microsoft.EntityFrameworkCore;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;
using ProductInventoryManager.Persistence.DatabaseContext;

namespace ProductInventoryManager.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductInventoryManagerDataBaseContext context) : base(context)
        {
        }
        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}