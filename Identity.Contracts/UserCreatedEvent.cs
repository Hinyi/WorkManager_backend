namespace Identity.Contracts;

public record UserCreatedEvent
{
    public string Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}