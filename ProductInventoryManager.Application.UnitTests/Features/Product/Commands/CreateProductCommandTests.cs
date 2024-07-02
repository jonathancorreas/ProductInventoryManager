using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Product.Commands.CreateProduct;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Product.Commands
{
    public class CreateProductCommandTests
    {
        private readonly Mock<IProductRepository> _mockRepoProduct;
        private readonly Mock<ICategoryRepository> _mockRepoCategory;
        private IMapper _mapper;
        public CreateProductCommandTests()
        {
            _mockRepoProduct = MockProductRepository.GetMockProductRepository();
            _mockRepoCategory = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateProduct()
        {
            var handler = new CreateProductCommandHandler(_mapper, _mockRepoProduct.Object, _mockRepoCategory.Object);
            var createProductCommand = new CreateProductCommand
            {
                Name = "Producto 4",
                Description = "Descripcion producto 4",
                Price=400,
                CategoryId=1,
                InventoryCount=400

            };
            await handler.Handle(createProductCommand, CancellationToken.None);
            var products = await _mockRepoProduct.Object.GetAsync();
            var createdProduct = products.FirstOrDefault(c => c.Name == createProductCommand.Name && c.Description == createProductCommand.Description);
            createdProduct.ShouldNotBeNull();
            createdProduct.Name.ShouldBe(createProductCommand.Name);
            createdProduct.Description.ShouldBe(createProductCommand.Description);
        }
    }
}