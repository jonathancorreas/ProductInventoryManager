using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Product.Commands.DeleteProduct;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Product.Commands
{
    public class DeleteProductCommandTests
    {        
        private readonly Mock<IProductRepository> _mockRepoProduct;                
        public DeleteProductCommandTests()
        {
            _mockRepoProduct = MockProductRepository.GetMockProductRepository();            
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductProfile>();
            });            
        }

        [Fact]
        public async Task DeleteProduct()
        {            
            var handler = new DeleteProductCommandHandler(_mockRepoProduct.Object);
            var deleteProductCommand = new DeleteProductCommand
            {
                Id = 1
            };           
            await handler.Handle(deleteProductCommand, CancellationToken.None);            
            var categories = await _mockRepoProduct.Object.GetAsync();
            var deletedProduct = categories.FirstOrDefault(c => c.Id == deleteProductCommand.Id);
            deletedProduct.ShouldBeNull();            
        }
    }
}