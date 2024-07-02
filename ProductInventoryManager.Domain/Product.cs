using ProductInventoryManager.Domain.Common;

namespace ProductInventoryManager.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int InventoryCount { get; set; }
    }
}