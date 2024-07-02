using AutoMapper;
using InventoryMovementInventoryManager.Application.UnitTests.Mocks;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.InventoryMovement.Commands.CreateInventoryMovement;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.InventoryMovement.Commands
{
    public class CreateInventoryMovementCommand
    {
        private readonly Mock<IProductRepository> _mockRepoProduct;
        private readonly Mock<IInventoryMovementRepository> _mockRepoInventoryMovement;
        private readonly Mock<IMovementTypeRepository> _mockRepoMovementType;
        private IMapper _mapper;

        public CreateInventoryMovementCommand()
        {
            _mockRepoProduct = MockProductRepository.GetMockProductRepository();
            _mockRepoInventoryMovement = MockInventoryMovementRepository.GetMockInventoryMovementRepository();
            _mockRepoMovementType = MockMovementTypeRepository.GetMockMovementTypeRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<InventoryMovementProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateInventoryMovement()
        {
            var handler = new CreateInventoryMovementCommandHandler(_mapper, _mockRepoInventoryMovement.Object, _mockRepoMovementType.Object, _mockRepoProduct.Object);
            var createInventoryMovementCommand = new Application.Features.InventoryMovement.Commands.CreateInventoryMovement.CreateInventoryMovementCommand
            {
                MovementTypeId = 1,
                ProductId=1,
                Quantity=250,
                Description="Ingresan 5 productos.",                               
            };
            await handler.Handle(createInventoryMovementCommand, CancellationToken.None);
            var inventoryMovements = await _mockRepoInventoryMovement.Object.GetAsync();
            var createdinventoryMovement = inventoryMovements.FirstOrDefault(c => c.ProductId == createInventoryMovementCommand.ProductId && c.Description == createInventoryMovementCommand.Description);
            createdinventoryMovement.ShouldNotBeNull();
            createdinventoryMovement.Description.ShouldBe(createdinventoryMovement.Description);
            createdinventoryMovement.ProductId.ShouldBe(createdinventoryMovement.ProductId);
        }
    }
}