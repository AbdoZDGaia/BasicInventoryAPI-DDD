using Inventory.Domain.Domains.Categories;
using Inventory.Domain.Domains.Products;
using Inventory.Domain.Domains.ProductStatuses;
using Inventory.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStatus> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public InventoryDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(o => o.Weight).HasPrecision(18, 4);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
