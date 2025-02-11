using System.Security.Cryptography;
using System.Text;

namespace IdentityService.Services;

public static class PasswordHasher
{
    internal static string GetHash(string input)
    {
        var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    internal static bool ValidatePassword(string input, string hash)
    {
        return GetHash(input) == hash;
    }
    
}