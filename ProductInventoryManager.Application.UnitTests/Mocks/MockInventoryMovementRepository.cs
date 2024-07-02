using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;

namespace InventoryMovementInventoryManager.Application.UnitTests.Mocks
{
    public class MockInventoryMovementRepository
    {
        public static Mock<IInventoryMovementRepository> GetMockInventoryMovementRepository()
        {
            var inventoryMovements = new List<InventoryMovement>
            {
                new InventoryMovement
                {
                    Id = 1,
                    ProductId=1,
                    MovementTypeId = 1,
                    Quantity=100,
                    Description="Ingresa 100 elementos",
                    MovementDate= DateTime.Now

                },
                new InventoryMovement
                {
                    Id = 1,
                    ProductId=2,
                    MovementTypeId = 2,
                    Quantity=500,
                    Description="Salen 500 elementos",
                    MovementDate= DateTime.Now
                }
            };
            var mockRepo = new Mock<IInventoryMovementRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(inventoryMovements);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<InventoryMovement>()))
                .Returns((InventoryMovement InventoryMovement) =>
                {
                    inventoryMovements.Add(InventoryMovement);
                    return Task.CompletedTask;
                });
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    return inventoryMovements.FirstOrDefault(c => c.Id == id);
                });

            return mockRepo;
        }
    }
}