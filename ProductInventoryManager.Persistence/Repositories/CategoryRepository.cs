using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;
using ProductInventoryManager.Persistence.DatabaseContext;

namespace ProductInventoryManager.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductInventoryManagerDataBaseContext context) : base(context)
        {            
        }
    }
}