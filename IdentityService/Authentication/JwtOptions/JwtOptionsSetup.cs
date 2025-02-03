using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IdentityService.Authentication.JwtOptions;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string SectionsName = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionsName).Bind(options);
    }
}