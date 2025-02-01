using System.Net;
using Shared.Exceptions;

namespace IdentityService.Exceptions;

public class UserNotFound : WorkManagerException
{
    public UserNotFound(string message, string requestId) : base(message)
    {
    }    
    public UserNotFound(string requestId) : base($"User not found with id: {requestId}")
    {
    }    
    public UserNotFound() : base("User not found")
    {
    }
    public override HttpStatusCode StatusCode { get; }
}