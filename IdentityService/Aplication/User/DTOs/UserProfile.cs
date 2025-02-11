using AutoMapper;
using IdentityService.Aplication.User.Command.CreateUser;

namespace IdentityService.Aplication.User.DTOs;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, Entities.User>();
        CreateMap<Entities.User, UserDTO>();
    }
}