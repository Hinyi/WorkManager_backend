using AutoMapper;
using IdentityService.Aplication.User.Command.CreateUser;
using IdentityService.Entities;
using IdentityService.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;

namespace IdentityService.Tests.Aplication.Commands.CreateUser;

public class CreateUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateUser_WhenUserDoesNotExist()
    {
        // Arrange
        // var mediatorMock = new Mock<IMediator>();
        var loogerMock = new Mock<ILogger<CreateUserCommandHandler>>();
        var mapperMock = new Mock<IMapper>();
        //
        // var command = new CreateUserCommand();
        // var user = new User();
        //
        // mapperMock.Setup(m => m.Map<User>(command)).Returns(user);
        //
        //
        // var userRepositoryMock = new Mock<IUserRepository>();
        // userRepositoryMock
        //     .Setup(repo => repo.AddUser(It.IsAny<User>()))
        //     .Returns(user);
        //
        // var userContextMock = new Mock<IUserContext>();
        //Act


        //Assert



    }
}