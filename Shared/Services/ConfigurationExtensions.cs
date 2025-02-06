using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Services;
//Not used in this project
public static class ConfigurationExtensions
{
    // following line implemented in IServiceCollectionExtensions add reading Jwt components from appsettings.json
    //var options = services.GetOptions<JwtBearerOptions>("Jwt");
    public static TModel GetOptions<TModel>(this IServiceCollection service, string sectionName)
        where TModel : new()
    {
        var model = new TModel();
        var configuration = service.BuildServiceProvider().GetService<IConfiguration>();
        configuration?.GetSection(sectionName).Bind(model);
        return model;
    }

}