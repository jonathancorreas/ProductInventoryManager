using ProductInventoryManager.Domain.Common;

namespace ProductInventoryManager.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}