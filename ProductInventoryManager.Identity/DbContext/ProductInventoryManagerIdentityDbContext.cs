using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductInventoryManager.Identity.Models;

namespace ProductInventoryManager.Identity.DbContext
{
    public class ProductInventoryManagerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductInventoryManagerIdentityDbContext(DbContextOptions<ProductInventoryManagerIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductInventoryManagerIdentityDbContext).Assembly);
        }
    }
}