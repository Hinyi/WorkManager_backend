using FluentValidation;
using FluentValidation.AspNetCore;
using IdentityService.Aplication.User.Command.CreateUserCommand;
using IdentityService.Aplication.User.DTOs;
using IdentityService.Interface;
using IdentityService.Persistence;
using IdentityService.Repositories;
using IdentityService.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdentityService;

public static class DependencyInjection
{
    public static IServiceCollection Users(this IServiceCollection services, IConfiguration configuration)
    {
        // var options = configuration.GetOptions<PostgresOptions>("UserDb");
        //
        services.AddDbContext<UserDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("UserDb")));

        var applicationAssembly = typeof(DependencyInjection).Assembly;

        // Add MediatR to user entities
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<UserAssemblyReference>();
            // cfg.AddBehavior(typeof(IPipelineBehavior<,>) ,typeof(ValidationBehavior<,>));
        });

         // Add AutoMapper to user entities
        services.AddAutoMapper(typeof(UserProfile).Assembly);


        // Validation setup - important to get this right
        // services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);
        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Optional: Add automatic validation for API controllers
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddHttpContextAccessor();

        
         return services;
    }
}