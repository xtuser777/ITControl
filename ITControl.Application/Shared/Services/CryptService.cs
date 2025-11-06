using System.Security.Cryptography;
using ITControl.Application.Shared.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ITControl.Application.Shared.Services;

public class CryptService(IConfiguration configuration) : ICryptService
{
    public string HashPassword(string password)
    {
        var salt = configuration["Hash:Salt"]!;
        var saltBytes = Convert.FromBase64String(salt);
        var iterations = int.Parse(configuration["Hash:Iterations"]!);
        var size = int.Parse(configuration["Hash:Size"]!);
        var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            iterations,
            HashAlgorithmName.SHA256 // Or other hash algorithm used
        );
        var key = pbkdf2.GetBytes(size);
        
        return Convert.ToBase64String(key);
    }

    private static bool ByteArraysEqual(byte[] b1, byte[] b2)
    {
        if (b1 == b2) return true;
        if (b1.Length != b2.Length) return false;
        return !b1.Where((t, i) => t != b2[i]).Any();
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        var encryptedData = Convert.FromBase64String(hashedPassword);
        var keyStr = HashPassword(password);
        var key = Convert.FromBase64String(keyStr);

        return ByteArraysEqual(encryptedData, key);
    }
}