using ITControl.Domain.Users.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Communication.Users.Requests;

public record OrderByUsersRequest
{
    [FromHeader(Name = "X-Order-By-Username")]
    public string? Username { get; set; }
    [FromHeader(Name = "X-Order-By-Name")]
    public string? Name { get; set; }
    [FromHeader(Name = "X-Order-By-Email")]
    public string? Email { get; set; }
    [FromHeader(Name = "X-Order-By-Active")]
    public string? Active { get; set; }

    public static implicit operator OrderByUsersParams(
        OrderByUsersRequest request)
        => new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = request.Active
        };
}