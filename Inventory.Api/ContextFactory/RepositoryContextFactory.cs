using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inventory.Api.ContextFactory
{
    public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
    {
        public InventoryDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseSqlServer(config.GetConnectionString("SqlConnection"),
                options => options.MigrationsAssembly("Inventory.Api"));

            return new InventoryDbContext(builder.Options);
        }
    }
}
