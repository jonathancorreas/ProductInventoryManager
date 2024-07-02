using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.UnitTests.Mocks
{
    public class MockMovementTypeRepository
    {
        public static Mock<IMovementTypeRepository> GetMockMovementTypeRepository()
        {
            var categories = new List<MovementType>
            {
                new MovementType
                {
                    Id = 1,
                    Name = "Entrada"
                },
                new MovementType
                {
                    Id = 2,
                    Name = "Salida",                    
                }
            };
            var mockRepo = new Mock<IMovementTypeRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(categories);
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    return categories.FirstOrDefault(c => c.Id == id);
                });
            
            return mockRepo;
        }
    }
}