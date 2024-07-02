using MediatR;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetInventoryMovementDetails
{
    public record GetInventoryMovementDetailsQuery(int Id) : IRequest<InventoryMovementDetailsDto>;
}