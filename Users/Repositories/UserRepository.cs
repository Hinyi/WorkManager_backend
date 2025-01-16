using Users.Entities;
using Users.Entities.ValueObject;
using Users.Interface;

namespace Users.Repositories;

public class UserRepository :IUserRepository
{
    public async Task AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserById(UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}