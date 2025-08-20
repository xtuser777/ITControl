using ITControl.Application.Interfaces;
using ITControl.Application.Utils;
using ITControl.Communication.Auth.Requests;
using ITControl.Communication.Auth.Responses;
using ITControl.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ITControl.Application.Services;

public class AuthService(
    ITokenService tokenService, 
    IUnitOfWork unitOfWork, 
    IConfiguration configuration) : IAuthService
{
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        User user = await Validate(request.Username, request.Password);

        var payload = new LoginPayload()
        {
            Sub = user.Id.ToString(),
            Role = user.Role?.Name ?? "",
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

    public async Task<PermissionsResponse> Permissions(Guid userId, PermissionsRequest request)
    {
        Guid roleId = Parser.ToGuidOptional(request.RoleId) 
            ?? throw new UnauthorizedAccessException("Perfil inválido.");
        var role = await unitOfWork.RolesRepository.FindOneAsync(x => x.Id == roleId, true) 
            ?? throw new UnauthorizedAccessException("Perfil não encontrado.");
        if (!role.Active)
        {
            throw new UnauthorizedAccessException("Perfil inativo.");
        }

        List<Guid> pagesIds = role.RolesPages != null ? [.. role.RolesPages.Select(x => x.PageId)] : [];

        List<Page?> pages = [];
        foreach (var pageId in pagesIds)
        {
            var page = await unitOfWork.PagesRepository.FindOneAsync(x => x.Id == pageId);
            pages.Add(page);
        }

        List<string> permissions = [.. pages.Where(x => x != null).Select(x => x!.Name)];

        PermissionsPayload payload = new PermissionsPayload()
        {
            Sub = userId.ToString(),
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

        return new PermissionsResponse()
        {
            AccessToken = token,
            ExpiresIn = 60 * 24 * 7,
        };
    }

    private async Task<User> Validate(string username, string password)
    {
        var user = await unitOfWork.UsersRepository.FindOneAsync(
                       x => x.Username == username, 
                       null, 
                       true, 
                       null, 
                       null) 
            ?? throw new UnauthorizedAccessException("Usuário inválido.");
        if (!user.Active)
        {
            throw new UnauthorizedAccessException("Usuário inativo.");
        }
        if (Crypt.VerifyHashedPassword(user.Password, password) == false)
        {
            throw new UnauthorizedAccessException("Senha inválida.");
        }

        return (User)user;
    }
}
