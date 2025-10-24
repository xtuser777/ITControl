using ITControl.Application.Shared.Params;
using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Utils;
using ITControl.Domain.Users.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Users.Params;

public record IndexUsersParams : PaginationParams
{
    public string? Username { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Active { get; init; }
    
    [FromHeader(Name = "X-Order-By-Username")]
    public string? OrderByUsername { get; init; }
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; init; }
    [FromHeader(Name = "X-Order-By-Email")]
    public string? OrderByEmail { get; init; }
    [FromHeader(Name = "X-Order-By-Active")]
    public string? OrderByActive { get; init; }

    public static implicit operator OrderByUsersParams(
        IndexUsersParams request)
        => new()
        {
            Username = request.OrderByUsername,
            Name = request.OrderByName,
            Email = request.OrderByEmail,
            Active = request.OrderByActive
        };

    public static implicit operator FindManyUsersParams(
        IndexUsersParams request) =>
        new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = Parser.ToBoolOptional(request.Active),
        };

    public static implicit operator CountUsersParams(
        IndexUsersParams request) =>
        new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = Parser.ToBoolOptional(request.Active),
        };

    public static implicit operator FindManyServiceParams(
        IndexUsersParams param)
        => new()
        {
            FindManyParams = param,
            OrderByParams = param,
            PaginationParams = param,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexUsersParams param)
        => new()
        {
            CountParams = param,
            PaginationParams = param,
        };
}