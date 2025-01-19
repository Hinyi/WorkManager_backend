using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Aplication.User.Command.CreateUserCommand;

namespace API.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) 
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}