using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api
{
    public static class PrepareDb
    {
        public async static Task PopulateDb(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                var ctx = serviceScope.ServiceProvider.GetRequiredService<InventoryDbContext>();
                await SeedData(ctx);
            }
        }

        private async static Task SeedData(InventoryDbContext context)
        {
            Console.WriteLine("--> Attempting to apply migrations");
            try
            {
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

                if (pendingMigrations.Any())
                {
                    Console.WriteLine($"You have {pendingMigrations.Count()} pending migrations to apply.");
                    Console.WriteLine("Applying pending migrations now");
                    await context.Database.MigrateAsync();
                    
                    var lastAppliedMigration = (await context.Database.GetAppliedMigrationsAsync()).Last();

                    Console.WriteLine($"You're on schema version: {lastAppliedMigration}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Unable to apply migrations: {ex.Message}");
            }
        }
    }
}
