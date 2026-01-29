using MediatR;

namespace Task.Application.Commands.AddNewTask;

public record AddNewTaskCommandResponse(string id);

public record AddNewTaskCommand(string Title, string Description) : IRequest<AddNewTaskCommandResponse>;
