using System.Text.Json;
using System.Text.Json.Serialization;
using IdentityService.Entities;
using IdentityService.Interface;
using IdentityService.Persistence;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace IdentityService.Repositories.UserRepository;

public class CachedUserRepository : IUserRepository
{
    private readonly IUserRepository _decoratedUser;
    private readonly IDistributedCache _distributedCache;
    private readonly UserDbContext _dbContext;

    public CachedUserRepository(IUserRepository decoratedUser, IDistributedCache distributedCache, UserDbContext dbContext)
    {
        _decoratedUser = decoratedUser;
        _distributedCache = distributedCache;
        _dbContext = dbContext;
    }

    public async Task AddUser(User user) =>
        await _decoratedUser.AddUser(user);

    public async Task DeleteUser(User user) =>        
        await _decoratedUser.DeleteUser(user);

    public async Task<User?> GetUserById(string userId, CancellationToken cancellationToken = default)
    {
        string key = $"user-{userId}";
        var cachedUser = await _distributedCache.GetStringAsync(key, cancellationToken);

        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2),
        };

        User? user;
        if (string.IsNullOrEmpty(cachedUser))
        {
            user = await _decoratedUser.GetUserById(userId, cancellationToken);
            if(user is null)
            {
                return user;
            }

            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(user),
                cacheOptions,
                cancellationToken);

            return user;
        }
        
        user = JsonConvert.DeserializeObject<User>(cachedUser);

        if (user is not null)
        {
            _dbContext.Set<User>().Attach(user);
        }

        return user;
    }

    public async Task<User?> GetUserByEmail(string email) =>
        await _decoratedUser.GetUserByEmail(email);

    public async Task<User> UpdateUser(User user) =>
        await _decoratedUser.UpdateUser(user);
}