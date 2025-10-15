using ITControl.Communication.Roles.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Headers;

public record OrderByRolesHeaders
{
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; } = null;

    [FromHeader(Name = "X-Order-By-Active")]
    public string? Active { get; set; } = null;

    public static implicit operator OrderByRolesRequest(OrderByRolesHeaders request) => new()
    {
        Name = request.Name,
        Active = request.Active
    };
}
