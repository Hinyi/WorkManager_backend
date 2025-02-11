using System.Net;
using Shared.Exceptions;

namespace IdentityService.Exceptions;

public class InvalidPassword : WorkManagerException
{
    public InvalidPassword() : base("Invalid password")
    {
    }    
    public override HttpStatusCode StatusCode { get; }
}