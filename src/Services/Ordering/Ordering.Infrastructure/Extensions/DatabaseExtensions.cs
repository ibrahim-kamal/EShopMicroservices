using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public async static Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.MigrateAsync().GetAwaiter().GetResult();
            await SeedAsync(context);
        }

        private async static Task SeedAsync(ApplicationDbContext context)
        {
            await SeedCustomerAsync(context);
            await SeedProductAsync(context);
            await SeedOrderAndItemsAsync(context);

        }
        private async static Task SeedCustomerAsync(ApplicationDbContext context)
        {
            if (!await context.Customers.AnyAsync()) {
                await context.Customers.AddRangeAsync(InitialiseData.Customers);
                await context.SaveChangesAsync();
            }
        }
        private async static Task SeedProductAsync(ApplicationDbContext context)
        {
            if (!await context.Products.AnyAsync()) {
                await context.Products.AddRangeAsync(InitialiseData.Products);
                await context.SaveChangesAsync();
            }
        }
        private async static Task SeedOrderAndItemsAsync(ApplicationDbContext context)
        {
            if (!await context.Orders.AnyAsync()) {
                await context.Orders.AddRangeAsync(InitialiseData.OrdersWithItems);
                await context.SaveChangesAsync();
            }
        }
    }
}
