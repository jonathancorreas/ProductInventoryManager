using AutoMapper;
using InventoryMovementInventoryManager.Application.UnitTests.Mocks;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.InventoryMovement.Queries.GetInventoryMovementDetails;
using ProductInventoryManager.Application.MappingProfiles;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.InventoryMovement.Queries
{
    public class GetInventoryMovementsDetailsQueryHandlerTests
    {
        private readonly Mock<IInventoryMovementRepository> _mockRepo;
        private IMapper _mapper;
        public GetInventoryMovementsDetailsQueryHandlerTests()
        {
            _mockRepo = MockInventoryMovementRepository.GetMockInventoryMovementRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<InventoryMovementProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetInventoryMovementTest()
        {
            var handler = new GetInventoryMovementDetailsQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetInventoryMovementDetailsQuery(1), CancellationToken.None);
            result.ShouldBeOfType<InventoryMovementDetailsDto>();
            result.Id.ShouldBe(1);
        }
    }
}