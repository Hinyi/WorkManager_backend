using Microsoft.AspNetCore.Routing;

namespace Shared.Services;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}