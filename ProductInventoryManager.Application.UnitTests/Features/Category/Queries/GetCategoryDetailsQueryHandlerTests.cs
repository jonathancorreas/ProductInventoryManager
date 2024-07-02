using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Category.Queries.GetCategoryDetails;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Category.Queries
{
    public class GetCategoryDetailsQueryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private IMapper _mapper;
        public GetCategoryDetailsQueryHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCategoryTest()
        {
            var handler = new GetCategoryDetailsQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetCategoryDetailsQuery(1), CancellationToken.None);
            result.ShouldBeOfType<CategoryDetailsDto>();
            result.Id.ShouldBe(1);
        }
    }
}