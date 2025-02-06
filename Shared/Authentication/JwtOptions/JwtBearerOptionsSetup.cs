using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Shared.Authentication.JwtOptions;

public class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
{
    // private readonly Shared.Authentication.JwtOptions _jwtOptions;
    //
    // public JwtBearerOptionsSetup(Shared.Authentication.JwtOptions jwtOptions)
    // {
    //     _jwtOptions = jwtOptions;
    // }
    //
    // public void PostConfigure(string? name, JwtBearerOptions options)
    // {
    //     options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
    //     options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
    //     options.TokenValidationParameters.IssuerSigningKey =
    //         new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
    // }
    public void PostConfigure(string? name, JwtBearerOptions options)
    {
        throw new NotImplementedException();
    }
}