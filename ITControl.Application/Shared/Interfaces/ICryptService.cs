namespace ITControl.Application.Shared.Interfaces;

public interface ICryptService
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string password);
}