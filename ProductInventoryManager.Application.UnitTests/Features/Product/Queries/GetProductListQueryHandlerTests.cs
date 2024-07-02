using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Product.Queries.GetAllProducts;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Product.Queries
{
    public class GetProductListQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private IMapper _mapper;        

        public GetProductListQueryHandlerTests()
        {
            _mockRepo = MockProductRepository.GetMockProductRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductsQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetProductsQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(3);
        }
    }
}