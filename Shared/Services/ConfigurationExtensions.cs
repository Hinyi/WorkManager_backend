using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Services;

public static class ConfigurationExtensions
{
    public static TModel GetOptions<TModel>(this IServiceCollection service, string sectionName)
        where TModel : new()
    {
        var model = new TModel();
        var configuration = service.BuildServiceProvider().GetService<IConfiguration>();
        configuration?.GetSection(sectionName).Bind(model);
        return model;
    }

}