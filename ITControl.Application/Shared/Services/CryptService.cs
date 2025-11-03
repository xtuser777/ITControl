using System.Security.Cryptography;
using System.Text;
using ITControl.Application.Shared.Interfaces;
using ITControl.Domain.Users.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
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
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            iterations,
            HashAlgorithmName.SHA256 // Or other hash algorithm used
        );

        byte[] key = pbkdf2.GetBytes(size);
        
        return Convert.ToBase64String(key);
    }

    private static bool ByteArraysEqual(byte[] b1, byte[] b2)
    {
        if (b1 == b2) return true;
        if (b1.Length != b2.Length) return false;
        return !b1.Where((t, i) => t != b2[i]).Any();
    }
    
    public static byte[] ComputeSha256HashAndBase64Encode(string rawData)
    {
        // Create a SHA256 hash object
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return bytes;
        }
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        byte[] encryptedData = Convert.FromBase64String(hashedPassword);
        var salt = configuration["Hash:Salt"]!;
        var saltBytes = Convert.FromBase64String(salt);
        var iterations = int.Parse(configuration["Hash:Iterations"]!);
        var size = int.Parse(configuration["Hash:Size"]!);
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            iterations,
            HashAlgorithmName.SHA256 // Or other hash algorithm used
        );

        byte[] key = pbkdf2.GetBytes(size);

        return ByteArraysEqual(encryptedData, key);
    }

    public bool Test()
    {
        var password = "1nf0.pmr";
        var salt = configuration["Hash:Salt"]!;
        var saltBytes = Convert.FromBase64String(salt);
        var iterations = int.Parse(configuration["Hash:Iterations"]!);
        var size = int.Parse(configuration["Hash:Size"]!);
        Rfc2898DeriveBytes pbkdf21 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            iterations,
            HashAlgorithmName.SHA256 // Or other hash algorithm used
        );

        byte[] key1 = pbkdf21.GetBytes(size);
        
        var hashedPassword = Convert.ToBase64String(key1);
        byte[] encryptedData = Convert.FromBase64String(hashedPassword);
        Rfc2898DeriveBytes pbkdf22 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            iterations,
            HashAlgorithmName.SHA256 // Or other hash algorithm used
        );

        byte[] key2 = pbkdf22.GetBytes(size);

        return ByteArraysEqual(encryptedData, key2);
    }
}