using ITControl.Communication.Auth.Requests;
using ITControl.Communication.Auth.Responses;

namespace ITControl.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
