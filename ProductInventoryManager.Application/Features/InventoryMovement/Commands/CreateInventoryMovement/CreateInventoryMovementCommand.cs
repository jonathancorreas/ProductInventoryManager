using MediatR;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Commands.CreateInventoryMovement
{
    public class CreateInventoryMovementCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int MovementTypeId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }        
    }
}