using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetAllInventoryMovements
{
    public class GetInventoryMovementsQueryHandler : IRequestHandler<GetInventoryMovementsQuery, List<InventoryMovementDto>>
    {
        private readonly IMapper _mapper;
        private readonly IInventoryMovementRepository _inventoryMovementRepository;

        public GetInventoryMovementsQueryHandler(IMapper mapper, IInventoryMovementRepository inventoryMovementRepository)
        {
            _mapper = mapper;
            _inventoryMovementRepository = inventoryMovementRepository;
        }

        public async Task<List<InventoryMovementDto>> Handle(GetInventoryMovementsQuery request, CancellationToken cancellationToken)
        {
            var inventoryMovements = await _inventoryMovementRepository.GetAsync();
            var data= _mapper.Map<List<InventoryMovementDto>>(inventoryMovements);

            return data;
        }
    }
}