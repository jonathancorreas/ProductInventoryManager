using Microsoft.EntityFrameworkCore;
using ProductInventoryManager.Domain;

namespace ProductInventoryManager.Persistence.DatabaseContext
{
    public class ProductInventoryManagerDataBaseContext : DbContext
    {
        public ProductInventoryManagerDataBaseContext(DbContextOptions<ProductInventoryManagerDataBaseContext> options) : base(options)
        {           
        }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductInventoryManagerDataBaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}