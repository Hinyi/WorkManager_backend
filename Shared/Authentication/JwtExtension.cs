using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Services;

namespace Shared.Authentication;

public static class JwtExtension
{
    public static IServiceCollection AddJwt(this IServiceCollection services,IConfiguration configuration)
    {
        var options = services.GetOptions<JwtBearerOptions>("Jwt");
        var settings = services.Configure<JwtSettings>(
            configuration.GetSection("Jwt"));

        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer({
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = options.ClaimsIssuer,
                ValidAudience = options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(options.ke.Secret))
            };
        })
        
        
        
        return services;
    }
}