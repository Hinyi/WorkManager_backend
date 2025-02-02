using IdentityService.Aplication.User.Command.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace IdentityService.Tests.Aplication.Commands.CreateUser;

public class CreateUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateUser_WhenUserDoesNotExist()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

    }
}