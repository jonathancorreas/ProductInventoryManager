using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;
using ProductInventoryManager.Persistence.DatabaseContext;

namespace ProductInventoryManager.Persistence.Repositories
{
    public class MovementTypeRepository : GenericRepository<MovementType>, IMovementTypeRepository
    {
        public MovementTypeRepository(ProductInventoryManagerDataBaseContext context) : base(context)
        {
        }
    }
}