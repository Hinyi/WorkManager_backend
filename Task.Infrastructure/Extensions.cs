using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.Infrastructure.Config;
using Microsoft.Extensions.Configuration;
using Task.Infrastructure.Context;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Task.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // services.Configure<MongoSettings>(configuration.GetConnectionString("MongoSettings"));
        services.AddDbContext<TaskDbContext>(options =>
        {
            var connectionString = configuration.GetSection("MongoSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoSettings:DatabaseName").Value;
            
            options.UseMongoDB(connectionString, databaseName);
        });
        return services;
    }
}