namespace ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetAllInventoryMovements
{
    public class InventoryMovementDto
    {
        public int ProductId { get; set; }
        public int MovementTypeId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime MovementDate { get; set; }
    }
}