using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Persistence;
using Users.Aplication.User.Command.CreateUserCommand;
using Users.Aplication.User.DTOs;
using Users.Interface;
using Users.Repositories;
using Users.Services;

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