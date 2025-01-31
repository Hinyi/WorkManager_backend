using System.Net;
using Shared.Exceptions;

namespace IdentityService.Exceptions;

public class UserNotFound : WorkManagerException
{
    public UserNotFound(string message, string requestId) : base(message)
    {
    }
    public override HttpStatusCode StatusCode { get; }
}