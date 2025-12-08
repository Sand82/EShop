namespace Ordering.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public async static Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDBContext context)
    {
       await SeedCustomersAsync(context);
       await SeedProductAsync(context);
       await SeedOrderAndItemsAsync(context);

    }

    private async static Task SeedCustomersAsync(ApplicationDBContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers());
            await context.SaveChangesAsync();
        }       
    }

    private async static Task SeedProductAsync(ApplicationDBContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products());
            await context.SaveChangesAsync();
        }
    }

    private async static Task SeedOrderAndItemsAsync(ApplicationDBContext context)
    {
        if (!await context.Orders.AnyAsync())
        {
            await context.Orders.AddRangeAsync(InitialData.OrdersWhitItems);
            await context.SaveChangesAsync();
        }
    }
}