using IdentityService.Application.User.DTOs;

namespace IdentityService.Application.User.DTOs;

public class UserExtension : IUserMapper
{
    public UserDTO MapToUserDto(Entities.User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        };
    }

    public Entities.User MapToUser(UserDTO userDtO)
    {
        return new Entities.User
        {
            Id = userDtO.Id,
            UserName = userDtO.UserName,
            Email = userDtO.Email,
        };
    }
}