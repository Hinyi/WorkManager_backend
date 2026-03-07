using MediatR;
using MongoDB.Bson;
using Task.Domain.Entities;
using Task.Infrastructure.Context;

namespace Task.Application.Commands.AddNewTask;

internal sealed class AddNewTaskCommandHandler : IRequestHandler<AddNewTaskCommand, AddNewTaskCommandResponse>
{
    private readonly TaskDbContext _context;

    public AddNewTaskCommandHandler(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<AddNewTaskCommandResponse> Handle(AddNewTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Id = new ObjectId().ToString(),
            Title = request.Title,
            Description = request.Description,
            IsCompleted = false,
            UserId = Guid.NewGuid()
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);

        var response = new AddNewTaskCommandResponse(
            "Task created"
        );
        return response;
    }
}