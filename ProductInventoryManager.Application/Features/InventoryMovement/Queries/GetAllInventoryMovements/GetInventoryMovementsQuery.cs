using MediatR;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetAllInventoryMovements
{
    public class GetInventoryMovementsQuery : IRequest<List<InventoryMovementDto>>
    {
    }
}