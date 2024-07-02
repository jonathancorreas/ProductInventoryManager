using ProductInventoryManager.Application.Contracts.Persistence;
using ProductInventoryManager.Persistence.DatabaseContext;
using ProductInventoryManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductInventoryManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            Console.WriteLine($"DbHost {dbHost}");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            Console.WriteLine($"DbName {dbName}");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            Console.WriteLine($"DbPassword {dbPassword}");
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True;";
            Console.WriteLine($"ConnectionString {connectionString}");
            services.AddDbContext<ProductInventoryManagerDataBaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryMovementRepository, InventoryMovementRepository>();
            services.AddScoped<IMovementTypeRepository, MovementTypeRepository>();

            return services;
        }
    }
}