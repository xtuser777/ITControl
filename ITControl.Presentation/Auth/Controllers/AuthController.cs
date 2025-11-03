using ITControl.Application.Auth.Interfaces;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Presentation.Auth.Interfaces;
using ITControl.Presentation.Auth.Requests;
using ITControl.Presentation.Auth.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(
        IAuthService authService,
        IAuthView authView) : ControllerBase
    {
        [HttpPost]
        public async Task<Shared.Responses.FindOneResponse<LoginResponse>> LoginAsync(
            [FromBody] LoginRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException("Request cannot be null.");
            }

            var token = await authService.Login(
                request.Username, request.Password);
            var data = authView.Login(token);

            return new Shared.Responses.FindOneResponse<LoginResponse>()
            {
                Data = data
            };
        }
    }
}
