using ITControl.Application.Auth.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Utils;
using ITControl.Communication.Auth.Requests;
using ITControl.Communication.Auth.Responses;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Users.Entities;
using Microsoft.Extensions.Configuration;

namespace ITControl.Application.Auth.Services;

public class AuthService(
    ITokenService tokenService, 
    IUnitOfWork unitOfWork, 
    IConfiguration configuration) : IAuthService
{
    [Obsolete("Obsolete")]
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var user = await Validate(request.Username, request.Password);
        var permissions = await Permissions(user.RoleId);

        var payload = new LoginPayload()
        {
            Sub = user.Id.ToString(),
            User = user.Name,
            Role = user.Role?.Id.ToString() ?? "",
            Permissions = permissions
        };

        var key = configuration["Jwt:Key"] ?? "";
        var issuer = configuration["Jwt:Issuer"] ?? "";
        var audience = configuration["Jwt:Audience"] ?? "";
        var token = tokenService.GenerateToken(
            key,
            issuer,
            audience,
            payload
        );

        return new LoginResponse() { AccessToken = token, ExpiresIn = 60 * 24 * 7 };
    }

    private async Task<List<string>> Permissions(Guid roleId)
    {
        var role = await unitOfWork.RolesRepository.FindOneAsync(roleId, true) 
            ?? throw new UnauthorizedAccessException(Errors.ROLE_NOT_FOUND);
        if (!role.Active)
        {
            throw new UnauthorizedAccessException(Errors.AUTH_ROLE_INACTIVE);
        }

        List<Guid> pagesIds = role.RolesPages != null ? [.. role.RolesPages.Select(x => x.PageId)] : [];

        List<Page?> pages = [];
        foreach (var pageId in pagesIds)
        {
            var page = await unitOfWork.PagesRepository.FindOneAsync(pageId);
            pages.Add(page);
        }

        List<string> permissions = [.. pages.Where(x => x != null).Select(x => x!.Name)];

        return permissions;
    }

    [Obsolete("Obsolete")]
    private async Task<User> Validate(string username, string password)
    {
        var user = await unitOfWork.UsersRepository.FindOneByUsernameAsync(username) 
            ?? throw new UnauthorizedAccessException(Errors.AUTH_INVALID_USER);
        if (!user.Active)
        {
            throw new UnauthorizedAccessException(Errors.AUTH_INACTIVE_USER);
        }
        if (Crypt.VerifyHashedPassword(user.Password, password) == false)
        {
            throw new UnauthorizedAccessException(Errors.AUTH_INVALID_PASSWORD);
        }

        return (User)user;
    }
}
