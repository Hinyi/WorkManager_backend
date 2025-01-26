using AutoMapper;
using IdentityService.Aplication.User.Command.CreateUserCommand;

namespace IdentityService.Aplication.User.DTOs;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, Entities.User>();
    }
}