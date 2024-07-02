using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}