using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task.Infrastructure.Config;
using Task.Infrastructure.Context;

namespace Task.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoSettings = configuration.GetSection("MongoSettings").Get<MongoSettings>();

        if (mongoSettings == null)
            throw new InvalidOperationException("MongoSettings section is missing in appsettings.json");

        if (string.IsNullOrEmpty(mongoSettings.ConnectionString))
            throw new InvalidOperationException("MongoDB ConnectionString is not configured");

        if (string.IsNullOrEmpty(mongoSettings.DatabaseName))
            throw new InvalidOperationException("MongoDB DatabaseName is not configured");

        services.AddDbContext<TaskDbContext>(options =>
        {
            // var connectionString = configuration.GetSection("MongoSettings:ConnectionString").Value;
            // var databaseName = configuration.GetSection("MongoSettings:DatabaseName").Value;

            options.UseMongoDB(mongoSettings.ConnectionString, mongoSettings.DatabaseName);
        });

        services.AddHttpContextAccessor();


        return services;
    }
}