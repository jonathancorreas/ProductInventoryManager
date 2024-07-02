using AutoMapper;
using MediatR;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Exceptions;

namespace ProductInventoryManager.Application.Features.InventoryMovement.Commands.CreateInventoryMovement
{
    public class CreateInventoryMovementCommandHandler : IRequestHandler<CreateInventoryMovementCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IInventoryMovementRepository _inventoryMovementRepository;
        private readonly IMovementTypeRepository _movementTypeRepository;
        private readonly IProductRepository _productRepository;
        private readonly int inventoryInbound = 1;
        private readonly int inventoryOutbound = 2;

        public CreateInventoryMovementCommandHandler(IMapper mapper, IInventoryMovementRepository inventoryMovementRepository, IMovementTypeRepository movementTypeRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _inventoryMovementRepository = inventoryMovementRepository;
            _movementTypeRepository = movementTypeRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateInventoryMovementCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateInventoryMovementCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Inventory Movement", validationResult);
            var movementType = await _movementTypeRepository.GetByIdAsync(request.MovementTypeId);
            if (movementType == null)
                throw new NotFoundException(nameof(movementType), request.MovementTypeId);
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new NotFoundException(nameof(product), request.ProductId);
            if (movementType.Id == inventoryInbound)
            {
                product.InventoryCount += request.Quantity;
            }
            else
            {
                if (request.Quantity > product.InventoryCount)
                {
                    validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.ProductId),
                        "The inventory quantity is less than the requested amount."));
                    throw new BadRequestException("Invalid Inventory Movement", validationResult);
                }
                product.InventoryCount -= request.Quantity;
            }
            await _productRepository.UpdateAsync(product);
            var inventoryMovementToCreate = _mapper.Map<Domain.InventoryMovement>(request);
            inventoryMovementToCreate.MovementDate = DateTime.Now;
            await _inventoryMovementRepository.CreateAsync(inventoryMovementToCreate);

            return inventoryMovementToCreate.Id;
        }
    }
}