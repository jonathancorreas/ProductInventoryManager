using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Product.Queries.GetProductDetails;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Product.Queries
{
    public class GetProductDetailsQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private IMapper _mapper;
        public GetProductDetailsQueryHandlerTests()
        {
            _mockRepo = MockProductRepository.GetMockProductRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductTest()
        {
            var handler = new GetProductDetailsQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetProductDetailsQuery(1), CancellationToken.None);
            result.ShouldBeOfType<ProductDetailsDto>();
            result.Id.ShouldBe(1);
        }
    }
}