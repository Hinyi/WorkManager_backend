using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Common;

namespace Task.Domain.Entities;

public class TaskEntity : AuditableEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
}