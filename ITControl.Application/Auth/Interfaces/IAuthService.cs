namespace ITControl.Application.Auth.Interfaces;

public interface IAuthService
{
    Task<string> Login(string username, string password);
}