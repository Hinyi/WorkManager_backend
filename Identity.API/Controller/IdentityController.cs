using IdentityService.Aplication.User.Command.CreateUser;
using IdentityService.Aplication.User.Command.LoginUser;
using IdentityService.Aplication.User.Command.RefreshToken;
using IdentityService.Aplication.User.Command.RevokeToken;
using IdentityService.Aplication.User.Queries.GetUserByEmail;
using IdentityService.Aplication.User.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controller;


[ApiController]
[Route("api/users")]
public sealed class IdentityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<IdentityController> _logger;

    public IdentityController(IMediator mediator, ILogger<IdentityController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
        
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
    {
        var response = await _mediator.Send(new GetUserByIdQuery(id));
        return Ok(response);
    }   
    [HttpGet("getUserByEmail")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var response = await _mediator.Send(new GetUserByEmailQuery(email));
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

    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> SomeResponse()
    {
        return Ok("Hello from Identity API");
    }
}