using Moq;
using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Application.UnitTests.Mocks
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetMockProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Producto 1",
                    Description= "Descripcion Producto 1",
                    Price = 10000,
                    CategoryId=1,
                    InventoryCount=100
                },
                new Product
                {
                    Id = 2,
                    Name = "Producto 2",
                    Description= "Descripcion Producto 2",
                    Price = 50000,
                    CategoryId=1,
                    InventoryCount=50
                },
                new Product
                {
                    Id = 3,
                    Name = "Producto 3",
                    Description= "Descripcion Producto 3",
                    Price = 10,
                    CategoryId=1,
                    InventoryCount=500
                },
            };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(products);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Product>()))
                .Returns((Product Product) =>
                {
                    products.Add(Product);
                    return Task.CompletedTask;
                });
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    return products.FirstOrDefault(c => c.Id == id);
                });
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>()))
                .Returns((Product Product) =>
                {
                    var existingProduct = products.FirstOrDefault(c => c.Id == Product.Id);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = Product.Name;
                        existingProduct.Description = Product.Description;
                    }
                    return Task.CompletedTask;
                });            
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Product>()))
                .Returns((Product Product) =>
                {
                    var existingProduct = products.FirstOrDefault(c => c.Id == Product.Id);
                    if (existingProduct != null)
                    {
                        products.Remove(existingProduct);
                    }
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}