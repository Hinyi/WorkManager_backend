using AutoMapper;
using IdentityService.Application.User.Command.CreateUser;
using IdentityService.Application.User.DTOs;

namespace IdentityService.Application.User.DTOs;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, Entities.User>();
        CreateMap<Entities.User, UserDTO>();
    }
}