using Microsoft.Extensions.DependencyInjection;

namespace Task.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here
        // Example: services.AddScoped<IUserService, UserService>();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });
        
        return services;
    }
}