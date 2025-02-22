using System.Net;
using Shared.Exceptions;

namespace IdentityService.Exceptions;

public class Unauthorized : WorkManagerException
{
    public Unauthorized(string message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode { get; }
}