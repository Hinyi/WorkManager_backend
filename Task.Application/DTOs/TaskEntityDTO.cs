namespace Task.Application.DTOs;

public class TaskEntityDTO
{
    public string Id {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public bool isCompleted {get; set;}
}