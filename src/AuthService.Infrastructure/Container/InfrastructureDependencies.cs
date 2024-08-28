using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AuthService.Infrastructure.Data.Context;

namespace AuthService.Infrastructure.Container;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureServices()
            .ConfigureDatabase(configuration);

        return services;
    }
    
    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        return services;
    }
    
    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbConnection")));

        return services;
    }
}