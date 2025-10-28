using ITControl.Presentation.Auth.Interfaces;
using ITControl.Presentation.Auth.Responses;

namespace ITControl.Presentation.Auth.Views;

public class AuthView : IAuthView
{
    public LoginResponse Login(string token)
    {
        return new LoginResponse
        {
            AccessToken = token, 
            ExpiresIn = 60 * 24 * 7
        };
    }
}