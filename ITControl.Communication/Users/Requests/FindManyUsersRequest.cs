using ITControl.Communication.Shared.Requests;
using ITControl.Domain.Users.Params;

namespace ITControl.Communication.Users.Requests;

public class FindManyUsersRequest : PageableRequest
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Active { get; set; }
    public string? OrderByUsername { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByEmail { get; set; }
    public string? OrderByActive { get; set; }

    public static implicit operator FindManyUsersRepositoryParams(FindManyUsersRequest request) =>
        new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = request.Active is not null ? request.Active == "true" : null,
            OrderByUsername = request.OrderByUsername,
            OrderByEmail = request.OrderByEmail,
            OrderByActive = request.OrderByActive,
            OrderByName = request.OrderByName,
            Page = request.Page is null ? null : int.Parse(request.Page),
            Size = request.Size is null ? null : int.Parse(request.Size),
        };
}