using MediatR;
using Task.Infrastructure.Context;

namespace Task.Application.Queries.GetAllTasks;

internal sealed class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<GetAllTasksResponse>>
{
    private readonly TaskDbContext _context;

    public GetAllTasksQueryHandler(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllTasksResponse>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var Query = _context.Tasks.ToList();

        return Query.Select(x =>
            new GetAllTasksResponse(x.Id, x.Title, x.Description, x.IsCompleted)).ToList();
    }
}