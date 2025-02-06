using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Shared.Authentication;

public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
{
    private const string SectionsName = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration.GetSection(SectionsName).Bind(options);
    }
}