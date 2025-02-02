using MediatR;
using Microsoft.AspNetCore.Mvc;
using IdentityService.Aplication.User.Command.CreateUserCommand;
using IdentityService.Aplication.User.Queries.GetUserByEmail;
using IdentityService.Aplication.User.Queries.GetUserById;

namespace API.Controllers;


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
}