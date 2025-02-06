using IdentityService.Entities;

namespace IdentityService.Authentication;

public interface IJwtProvider
{
    string GenereateJwtToken(User user);
}