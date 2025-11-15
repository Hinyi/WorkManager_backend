using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Task.API.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TaskController : ControllerBase
{
    private readonly IMediator _mediator;
    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
        // Constructor logic can be added here if needed
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        // Logic to get tasks can be added here
        var response = "It's my response";
        return Ok(response);
    }
    
}