using IdentityService.Application.User.Command.LoginUser;
using IdentityService.Application.User.Command.RefreshToken;
using IdentityService.Application.User.Command.RevokeToken;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Identity.API.Controller;

[ApiController]
[Route("auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;
    
    public AuthController(IMediator mediator, ILogger<AuthController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    //
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost("refreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPost("revokeToken")]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

}