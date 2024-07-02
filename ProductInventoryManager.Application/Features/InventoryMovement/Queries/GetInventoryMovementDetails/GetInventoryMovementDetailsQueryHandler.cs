using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetInventoryMovementDetails
{
    public class GetInventoryMovementDetailsQueryHandler : IRequestHandler<GetInventoryMovementDetailsQuery, InventoryMovementDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IInventoryMovementRepository _inventoryMovementRepository;

        public GetInventoryMovementDetailsQueryHandler(IMapper mapper, IInventoryMovementRepository inventoryMovementRepository)
        {
            _mapper = mapper;
            _inventoryMovementRepository = inventoryMovementRepository;
        }

        public async Task<InventoryMovementDetailsDto> Handle(GetInventoryMovementDetailsQuery request, CancellationToken cancellationToken)
        {            
            var inventoryMovement = await _inventoryMovementRepository.GetByIdAsync(request.Id);            
            if (inventoryMovement == null)
                throw new NotFoundException(nameof(inventoryMovement), request.Id);            
            var data = _mapper.Map<InventoryMovementDetailsDto>(inventoryMovement);
            
            return data;
        }
    }
}