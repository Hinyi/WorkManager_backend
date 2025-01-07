using Microsoft.AspNetCore.Identity;

namespace Users.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
}