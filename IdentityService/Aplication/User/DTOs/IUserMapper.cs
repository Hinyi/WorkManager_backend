namespace IdentityService.Aplication.User.DTOs;

public interface IUserMapper
{
    UserDTO MapToUserDto(Entities.User user);
    Entities.User MapToUser(UserDTO userDto);
}