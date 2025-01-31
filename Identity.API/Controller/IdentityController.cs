using MediatR;
using Microsoft.AspNetCore.Mvc;
using IdentityService.Aplication.User.Command.CreateUserCommand;
using IdentityService.Aplication.User.Queries.GetUserById;

namespace API.Controllers;

[ApiController]
[Route("api/users")]
public sealed class IdentityController : ControllerBase
{
    private readonly IMediator _mediator;

    public IdentityController(IMediator mediator) 
    {
        _mediator = mediator;
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
}