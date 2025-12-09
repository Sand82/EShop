using Microsoft.Extensions.Configuration;
using Ordering.Application.Data;
using Ordering.Infrastructure.Infrastructure;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDBContext>(( sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());            
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext, ApplicationDBContext>();

        return services;
    }
}
