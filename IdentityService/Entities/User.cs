using Microsoft.AspNetCore.Identity;

namespace IdentityService.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
}