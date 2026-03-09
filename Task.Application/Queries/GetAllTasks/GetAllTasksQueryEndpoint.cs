using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Services;

namespace Task.Application.Queries.GetAllTasks;

public class GetAllTasksQueryEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/tasksGetAll",
                async (IMediator mediator, CancellationToken cancellationToken) =>
                {
                    var result = await mediator.Send(new GetAllTasksQuery(), cancellationToken);
                    return result;
                }
            )
            .WithTags("Tasks")
            .Produces(400);
        ;
    }
}