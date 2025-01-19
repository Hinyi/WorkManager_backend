using AutoMapper;
using Users.Aplication.User.Command.CreateUserCommand;

namespace Users.Aplication.User.DTOs;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, Entities.User>();
    }
}