using ITControl.Presentation.Auth.Responses;

namespace ITControl.Presentation.Auth.Interfaces;

public interface IAuthView
{
    LoginResponse Login(string token);
}