using IdentityService.Entities;
using IdentityService.Interface;
using IdentityService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Repositories.UserRepository;

public sealed class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDb;

    public UserRepository(UserDbContext userDb)
    {
        _userDb = userDb;
    }
    
    public async Task AddUser(User user)
    {
        await _userDb.AddAsync(user);
        await _userDb.SaveChangesAsync();
    }
 
    public async Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserById(string userId, CancellationToken cancellationToken)
    {
        var user = await _userDb.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
        return user;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _userDb.Users
            .FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByRefreshToken(string refreshToken, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}