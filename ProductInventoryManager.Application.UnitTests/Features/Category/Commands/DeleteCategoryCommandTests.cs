using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Category.Commands.DeleteCategory;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Category.Commands
{
    public class DeleteCategoryCommandTests
    {
        private readonly Mock<ICategoryRepository> _mockRepoCategory;
        private readonly Mock<IProductRepository> _mockRepoProduct;
        public DeleteCategoryCommandTests()
        {
            _mockRepoCategory = MockCategoryRepository.GetMockCategoryRepository();
            _mockRepoProduct = MockProductRepository.GetMockProductRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });
        }

        [Fact]
        public async Task DeleteCategory()
        {
            var handler = new DeleteCategoryCommandHandler(_mockRepoCategory.Object, _mockRepoProduct.Object);
            var deleteCategoryCommand = new DeleteCategoryCommand
            {
                Id = 1
            };
            await handler.Handle(deleteCategoryCommand, CancellationToken.None);
            var categories = await _mockRepoCategory.Object.GetAsync();
            var deletedCategory = categories.FirstOrDefault(c => c.Id == deleteCategoryCommand.Id);
            deletedCategory.ShouldBeNull();
        }
    }
}