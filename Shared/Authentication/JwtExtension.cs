using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Shared.Authentication;

public static class JwtExtension
{
    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfigureOptions<JwtSettings>, JwtSettingsSetup>();
        
        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
        var key = Encoding.UTF8.GetBytes(jwtSettings!.SecretKey);
            //Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!);
        
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(
                options =>
                {
                    options.Authority = jwtSettings?.Authority;
                        //configuration["Jwt:Authority"]; 
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew =  TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings?.Issuer, //configuration["Jwt:Issuer"], 
                        ValidAudience = jwtSettings?.Audience,//configuration["Jwt:Audience"], 
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                            
                    };
                });


        return services;
    }

    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
                policy.RequireClaim("role", "Admin"));
        });

        return services;
    }
}