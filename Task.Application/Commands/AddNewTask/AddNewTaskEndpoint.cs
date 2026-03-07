using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Services;

namespace Task.Application.Commands.AddNewTask;

public class AddNewTaskEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/tasksNew",
                async (AddNewTaskCommand command, IMediator mediator, CancellationToken cancellationToken) =>
                {
                    var result = await mediator.Send(command, cancellationToken);
                    return result;
                })
            .WithTags("Tasks")
            .Produces<Guid>(201)
            .Produces(400);
    }
}