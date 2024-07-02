using ProductInventoryManager.Domain.Common;

namespace ProductInventoryManager.Domain
{
    public class InventoryMovement : BaseEntity
    {
        public int ProductId { get; set; }
        public int MovementTypeId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime MovementDate { get; set; }

    }
}