using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shared.Services.CurrentUserProvider;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor) : ICurrentUserProvider
{
    public Guid GerCurrentUserId()
    {
        var nameIdentifier = httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        Guid.TryParse(nameIdentifier, out var userId);

        return userId;
    }
}