using System.Net;

namespace Shared.Exceptions;

public abstract class WorkManagerException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    protected WorkManagerException(string message) : base(message) { }
}