using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsByCategory(int categoryId);
    }
}