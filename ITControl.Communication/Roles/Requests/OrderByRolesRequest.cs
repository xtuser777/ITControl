using ITControl.Domain.Roles.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Roles.Requests;

public record OrderByRolesRequest
{
    [FromRoute(Name = "X-Order-By-Name")]
    public string? Name { get; init; }
    [FromRoute(Name = "X-Order-By-Active")]
    public string? Active { get; init; }

    public static implicit operator OrderByRolesParams(
        OrderByRolesRequest request) => new()
    {
        Name = request.Name,
        Active = request.Active
    };
}