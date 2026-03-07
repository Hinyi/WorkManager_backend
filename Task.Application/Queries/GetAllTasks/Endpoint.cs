using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Task.Application.Queries.GetAllTasks;

public static class Endpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/tasks", async (IMediator mediator) =>
            {
                // var result = await mediator.Send(new GetAllTasksQuery());
                // return result;
            }
        );
    }
}