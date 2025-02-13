using Microsoft.AspNetCore.Identity;

namespace IdentityService.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}