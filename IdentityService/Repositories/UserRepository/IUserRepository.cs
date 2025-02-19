using IdentityService.Entities;
using IdentityService.Entities.ValueObject;

namespace IdentityService.Interface;

public interface IUserRepository
{
    Task AddUser(User user);
    Task DeleteUser(User user);
    Task<User?> GetUserById(string userId, CancellationToken cancellationToken);
    Task<User?> GetUserByEmail(string email);
}