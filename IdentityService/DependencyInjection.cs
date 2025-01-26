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

namespace IdentityService;

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
            cfg.AddBehavior(typeof(IPipelineBehavior<,>) ,typeof(ValidationBehavior<,>));
        });

         // Add AutoMapper to user entities
        services.AddAutoMapper(typeof(UserProfile).Assembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            // .AddFluentValidationAutoValidation();
       
        // services.AddValidatorsFromAssembly(typeof(Aplication.AssemblyReference).Assembly);
        // services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        // services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddHttpContextAccessor();

        
        // return services;
        
    }
}