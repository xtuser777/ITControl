using ITControl.Application.Auth.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Utils;
using ITControl.Domain.Pages.Entities;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Users.Entities;
using ITControl.Infrastructure.Users.Repositories;
using Microsoft.Extensions.Configuration;

namespace ITControl.Application.Auth.Services;

public class AuthService(
    ITokenService tokenService, 
    IUnitOfWork unitOfWork, 
    IConfiguration configuration) : IAuthService
{
    [Obsolete("Obsolete")]
    public async Task<string> Login(string username, string password)
    {
        var user = await Validate(username, password);
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

        return token;
    }

    private async Task<List<string>> Permissions(Guid roleId)
    {
        var role = await unitOfWork.RolesRepository.FindOneAsync(new() { 
            Id = roleId, 
            Includes = new IncludesRolesParams() { 
                RolesPages = new() {
                    Page = true 
                } 
            } 
        }) 
            ?? throw new UnauthorizedAccessException(Errors.ROLE_NOT_FOUND);
        if (!role.Active)
        {
            throw new UnauthorizedAccessException(Errors.AUTH_ROLE_INACTIVE);
        }

        List<Guid> pagesIds = role.RolesPages != null ? [
            .. role.RolesPages.Select(x => x.PageId)] : [];

        List<Page?> pages = [];
        foreach (var pageId in pagesIds)
        {
            var page = await unitOfWork.PagesRepository.FindOneAsync(
                new FindOneRepositoryParams() { Id = pageId });
            pages.Add(page);
        }

        List<string> permissions = [
            .. pages.Where(x => x != null).Select(x => x!.Name)];

        return permissions;
    }

    [Obsolete("Obsolete")]
    private async Task<User> Validate(string username, string password)
    {
        var user = await ((UsersRepository)unitOfWork.UsersRepository)
                       .FindOneByUsernameAsync(username) 
            ?? throw new UnauthorizedAccessException(Errors.AUTH_INVALID_USER);
        if (!user.Active)
        {
            throw new UnauthorizedAccessException(Errors.AUTH_INACTIVE_USER);
        }
        return !Crypt.VerifyHashedPassword(user.Password, password) 
            ? throw new UnauthorizedAccessException(Errors.AUTH_INVALID_PASSWORD) 
            : user;
    }
}
