using System.Net;
using Shared.Exceptions;

namespace IdentityService.Exceptions;

public class UserAlreadyExistExceptions : WorkManagerException
{
    public UserAlreadyExistExceptions(string message) : base(message)
    {
    }
    public override HttpStatusCode StatusCode { get; }
}