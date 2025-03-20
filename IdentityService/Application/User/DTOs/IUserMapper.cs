using IdentityService.Application.User.DTOs;

namespace IdentityService.Application.User.DTOs;

public interface IUserMapper
{
    UserDTO MapToUserDto(Entities.User user);
    Entities.User MapToUser(UserDTO userDto);
}