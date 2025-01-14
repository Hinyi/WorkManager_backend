using Users.Entities;
using Users.Entities.ValueObject;

namespace Users.Interface;

public interface IUserRepository
{
    Task AddUser(User user);
    Task DeleteUser(User user);
    Task<User?> GetUserById(UserId userId);
}