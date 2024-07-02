using AutoMapper;
using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Application.Features.Category.Commands.CreateCategory;
using ProductInventoryManager.Application.MappingProfiles;
using ProductInventoryManager.Application.UnitTests.Mocks;
using Shouldly;

namespace ProductInventoryManager.Application.UnitTests.Features.Category.Commands
{
    public class CreateCategoryCommandTests
    {
        private readonly Mock<ICategoryRepository> _mockRepo;
        private IMapper _mapper;
        public CreateCategoryCommandTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateCategory()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockRepo.Object);
            var createCategoryCommand = new CreateCategoryCommand
            {
                Name = "Categoria 4",
                Description = "Descripcion categoria 4"
            };
            await handler.Handle(createCategoryCommand, CancellationToken.None);
            var categories = await _mockRepo.Object.GetAsync();
            var createdCategory = categories.FirstOrDefault(c => c.Name == createCategoryCommand.Name && c.Description == createCategoryCommand.Description);
            createdCategory.ShouldNotBeNull();
            createdCategory.Name.ShouldBe(createCategoryCommand.Name);
            createdCategory.Description.ShouldBe(createCategoryCommand.Description);
        }
    }
}