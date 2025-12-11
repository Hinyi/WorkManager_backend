using IdentityService.Application.User.Command.LoginUser;
using IdentityService.Application.User.Command.RefreshToken;
using IdentityService.Application.User.Command.RevokeToken;
using IdentityService.Application.User.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Shared.Services.CurrentUserProvider;

namespace Identity.API.Controller;

[ApiController]
[Route("auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;
    private readonly ICurrentUserProvider _currentUserProvider;
    
    public AuthController(IMediator mediator, ILogger<AuthController> logger, ICurrentUserProvider currentUserProvider)
    {
        _mediator = mediator;
        _logger = logger;
        _currentUserProvider = currentUserProvider;
    }
    
    //
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var response = await _mediator.Send(command);
        
        Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            // Expires = DateTime.UtcNow.AddDays(7),
            Expires = response.ExpireAt,
            Path = "/"
        });
        
        return Ok(new{token = response.Token, refreshToken = response.RefreshToken});
    }
    [HttpPost("refreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPost("revokeToken")]
    public async Task<IActionResult> RevokeToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
        {
            return BadRequest("Refresh Token is missing");
        }
        
        var response = await _mediator.Send(new RevokeTokenCommand(refreshToken));
        
        Response.Cookies.Delete("refreshToken", new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Path = "/"
        });
        
        return Ok(response);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userId = _currentUserProvider.GerCurrentUserId();
        
        var user = await _mediator.Send(new GetUserByIdQuery(userId.ToString()));
        
        return Ok(user);
    }

}