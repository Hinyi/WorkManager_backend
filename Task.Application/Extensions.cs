using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Task.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var assembly = typeof(Extensions).Assembly;

        // Register application services here
        // Example: services.AddScoped<IUserService, UserService>();
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>(); });

        // Register all IEndpoint implementations from Application
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo<IEndpoint>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}