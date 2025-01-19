using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Persistence;
using Shared.Options;
using Users.Aplication.User.DTOs;
using Users.Interface;
using Users.Repositories;
using ServiceCollectionExtensions = FluentValidation.ServiceCollectionExtensions;

namespace Users;

public static class DependencyInjection
{
    public static IServiceCollection Users(this IServiceCollection services, IConfiguration configuration)
    {
        // var options = configuration.GetOptions<PostgresOptions>("UserDb");
        //
        services.AddDbContext<UserDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("UserDb")));
        
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<UserAssemblyReference>());

        services.AddAutoMapper(typeof(UserProfile).Assembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
        
        services.AddHttpContextAccessor();

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
        
        
    }
}