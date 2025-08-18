using ITControl.Communication.Auth.Requests;
using ITControl.Communication.Auth.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITControl.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<PermissionsResponse> Permissions(Guid userId, PermissionsRequest request);
    }
}
