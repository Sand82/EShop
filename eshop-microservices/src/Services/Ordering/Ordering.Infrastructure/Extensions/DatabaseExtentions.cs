using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Ordering.Infrastructure.Data;

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
    }

    private async static Task SeedCustomersAsync(ApplicationDBContext context)
    {
        if (!await context.Customers.AnyAsync())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers());
            await context.SaveChangesAsync();

        }

        throw new NotImplementedException();
    }
}
