namespace ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetInventoryMovementDetails
{
    public class InventoryMovementDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}