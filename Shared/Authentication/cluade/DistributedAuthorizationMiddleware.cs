using Microsoft.AspNetCore.Http;

namespace Shared.Authentication;

public class DistributedAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthService _authService;

    public async Task InvokeAsync(HttpContext context)
    {
        // Check for service-to-service or user token
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        if (token == null || !await _authService.ValidateTokenAsync(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next(context);
    }
    
}