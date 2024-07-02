using AutoMapper;
using InventoryMovementInventoryManager.Application.UnitTests.Mocks;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetAllInventoryMovements;
using ProductInventoryManager.Application.MappingProfiles;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.InventoryMovement.Queries
{
    public class GetInventoryMovementsListQueryHandlerTests
    {
        private readonly Mock<IInventoryMovementRepository> _mockRepo;
        private IMapper _mapper;        

        public GetInventoryMovementsListQueryHandlerTests()
        {
            _mockRepo = MockInventoryMovementRepository.GetMockInventoryMovementRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<InventoryMovementProfile>();
            });
            _mapper = mapperConfig.CreateMapper();            
        }

        [Fact]
        public async Task GetInventoryMovementListTest()
        {
            var handler = new GetInventoryMovementsQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetInventoryMovementsQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<InventoryMovementDto>>();
            result.Count.ShouldBe(2);
        }
    }
}