using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Exceptions;

namespace Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        
        return services;
    }
    
    public static IApplicationBuilder UseShared(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        return app;
    }
}