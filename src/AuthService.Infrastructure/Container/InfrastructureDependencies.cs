using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Container;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .ConfigureServices();

        return services;
    }
    
    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        return services;
    }
}