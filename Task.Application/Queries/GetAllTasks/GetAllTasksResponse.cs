namespace Task.Application.Queries.GetAllTasks;

public class GetAllTasksResponse
{
    public GetAllTasksResponse(string id, string title, string description, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }

    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}