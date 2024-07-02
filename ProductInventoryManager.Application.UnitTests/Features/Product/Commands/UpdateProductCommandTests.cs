using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Product.Commands.UpdateProduct;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Product.Commands
{
    public class UpdateProductCommandTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private IMapper _mapper;
        public UpdateProductCommandTests()
        {
            _mockRepo = MockProductRepository.GetMockProductRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateProduct()
        {            
            var handler = new UpdateProductCommandHandler(_mapper, _mockRepo.Object);
            var updatedProduct = new UpdateProductCommand
            {
                Id = 3,
                Name = "Producto 3 actualizado",
                Description = "Descripcion producto 3 actualizado",
                CategoryId=1,
                InventoryCount=500
            };            
            await handler.Handle(updatedProduct, CancellationToken.None);            
            var categories = await _mockRepo.Object.GetAsync();
            var updatedProductFromRepo = categories.FirstOrDefault(c => c.Id == updatedProduct.Id);
            updatedProductFromRepo.ShouldNotBeNull();
            updatedProductFromRepo.Name.ShouldBe(updatedProduct.Name);
            updatedProductFromRepo.Description.ShouldBe(updatedProduct.Description);           
        }
    }
}