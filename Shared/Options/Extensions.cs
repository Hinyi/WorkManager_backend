using Microsoft.Extensions.Configuration;

namespace Shared.Options;

public static class Extensions
{
    // This method is an extension method for IConfiguration - used to init mediatR but dont work...
    public static TOptions GetOptions<TOptions>(IConfiguration configuration, string sectionName) 
        where TOptions : new()
    {
        var options = new TOptions();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}