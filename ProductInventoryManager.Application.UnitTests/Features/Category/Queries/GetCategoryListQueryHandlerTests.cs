using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Category.Queries.GetAllCategories;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Category.Queries
{
    public class GetCategoryListQueryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private IMapper _mapper;        

        public GetCategoryListQueryHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });
            _mapper = mapperConfig.CreateMapper();            
        }

        [Fact]
        public async Task GetCategoryListTest()
        {
            var handler = new GetCategoriesQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetCategoriesQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(3);
        }
    }
}