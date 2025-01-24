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
    public static void Users(this IServiceCollection services, IConfiguration configuration)
    {
        // var options = configuration.GetOptions<PostgresOptions>("UserDb");
        //
        services.AddDbContext<UserDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("UserDb")));

        var applicationAssembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<UserAssemblyReference>();
            // cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

    // Add AutoMapper to user entities
        services.AddAutoMapper(typeof(UserProfile).Assembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
        // services.AddValidatorsFromAssembly(typeof(UserAssemblyReference).Assembly);
            // .AddFluentValidationAutoValidation();
       
        // services.AddValidatorsFromAssembly(typeof(Aplication.AssemblyReference).Assembly);
        // services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        // services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        services.AddHttpContextAccessor();

        services.AddScoped<IUserRepository, UserRepository>();
        
        // return services;
        
    }
}