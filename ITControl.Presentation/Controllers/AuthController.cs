using ITControl.Application.Interfaces;
using ITControl.Communication.Auth.Requests;
using ITControl.Communication.Auth.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost]
        public async Task<FindOneResponse<LoginResponse>> LoginAsync(
            [FromBody] LoginRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException("Request cannot be null.");
            }

            var data = await authService.Login(request);

            return new FindOneResponse<LoginResponse>()
            {
                Data = data
            };
        }

        [HttpPost("{userId:guid}/permissions")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<FindOneResponse<PermissionsResponse>> PermissionsAsync(
            [FromRoute] Guid userId, 
            [FromBody] PermissionsRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException("Request cannot be null.");
            }

            var data = await authService.Permissions(userId, request);

            return new FindOneResponse<PermissionsResponse>()
            {
                Data = data
            };
        }
    }
}
