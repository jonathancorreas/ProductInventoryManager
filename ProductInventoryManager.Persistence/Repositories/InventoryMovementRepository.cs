using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;
using ProductInventoryManager.Persistence.DatabaseContext;

namespace ProductInventoryManager.Persistence.Repositories
{
    public class InventoryMovementRepository : GenericRepository<InventoryMovement>, IInventoryMovementRepository
    {
        public InventoryMovementRepository(ProductInventoryManagerDataBaseContext context) : base(context)
        {            
        }
    }
}