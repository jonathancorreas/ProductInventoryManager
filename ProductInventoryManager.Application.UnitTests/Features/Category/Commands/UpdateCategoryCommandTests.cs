using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Category.Commands.UpdateCategory;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Category.Commands
{
    public class UpdateCategoryCommandTests
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private IMapper _mapper;
        public UpdateCategoryCommandTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateCategory()
        {
            var handler = new UpdateCategoryCommandHandler(_mapper, _mockRepo.Object);
            var updatedCategory = new UpdateCategoryCommand
            {
                Id = 3,
                Name = "Categoria 3 actualizada",
                Description = "Descripcion categoria 3 actualizado"
            };
            await handler.Handle(updatedCategory, CancellationToken.None);
            var categories = await _mockRepo.Object.GetAsync();
            var updatedCategoryFromRepo = categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
            updatedCategoryFromRepo.ShouldNotBeNull();
            updatedCategoryFromRepo.Name.ShouldBe(updatedCategory.Name);
            updatedCategoryFromRepo.Description.ShouldBe(updatedCategory.Description);
        }
    }
}