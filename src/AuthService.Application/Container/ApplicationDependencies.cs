using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application.Container;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
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