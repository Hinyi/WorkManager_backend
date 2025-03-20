using Shared.Common;

namespace Task.Domain.Entities;

public class TaskEntity : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid UserId { get; set; }
}