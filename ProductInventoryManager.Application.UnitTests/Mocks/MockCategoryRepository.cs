using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.UnitTests.Mocks
{
    public class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetMockCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Categoria 1",
                    Description= "Descripcion Categoria 1",
                },
                new Category
                {
                    Id = 2,
                    Name = "Categoria 2",
                    Description= "Descripcion Categoria 2",
                },
                new Category
                {
                    Id = 3,
                    Name = "Categoria 3",
                    Description= "Descripcion Categoria 3",
                }
            };
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(categories);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Category>()))
                .Returns((Category category) =>
                {
                    categories.Add(category);
                    return Task.CompletedTask;
                });

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    return categories.FirstOrDefault(c => c.Id == id);
                });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Category>()))
                .Returns((Category category) =>
                {
                    var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
                    if (existingCategory != null)
                    {
                        existingCategory.Name = category.Name;
                        existingCategory.Description = category.Description;
                    }
                    return Task.CompletedTask;
                });
            
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Category>()))
                .Returns((Category category) =>
                {
                    var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
                    if (existingCategory != null)
                    {
                        categories.Remove(existingCategory);
                    }
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}