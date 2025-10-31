using System.Security.Cryptography;

namespace ITControl.Application.Shared.Utils;

public abstract class Crypt
{
    public static string HashPassword(string password)
    {
        byte[] salt;
        byte[] buffer2;
        ArgumentNullException.ThrowIfNull(password);
        using (var bytes = new Rfc2898DeriveBytes(
                   password, 0x10, 0x3e8, HashAlgorithmName.SHA256))
        {
            salt = bytes.Salt;
            buffer2 = bytes.GetBytes(0x20);
        }
        var dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }

    private static bool ByteArraysEqual(byte[] b1, byte[] b2)
    {
        if (b1 == b2) return true;
        if (b1.Length != b2.Length) return false;
        return !b1.Where((t, i) => t != b2[i]).Any();
    }

    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
        byte[] buffer4;
        ArgumentNullException.ThrowIfNull(password);
        var src = Convert.FromBase64String(hashedPassword);
        if ((src.Length != 0x31) || (src[0] != 0))
        {
            return false;
        }
        var dst = new byte[0x10];
        Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        var buffer3 = new byte[0x20];
        Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);

        using (var bytes = new Rfc2898DeriveBytes(
                   password, dst, 0x3e8, HashAlgorithmName.SHA256))
        {
            buffer4 = bytes.GetBytes(0x20);
        }
        return ByteArraysEqual(buffer3, buffer4);
    }
}