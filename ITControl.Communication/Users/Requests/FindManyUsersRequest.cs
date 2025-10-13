using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Users.Params;

namespace ITControl.Communication.Users.Requests;

public record FindManyUsersRequest : PageableRequest
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
            Active = Parser.ToBoolOptional(request.Active),
            OrderByUsername = request.OrderByUsername,
            OrderByEmail = request.OrderByEmail,
            OrderByActive = request.OrderByActive,
            OrderByName = request.OrderByName,
            Page = Parser.ToIntOptional(request.Page),
            Size = Parser.ToIntOptional(request.Size),
        };

    public static implicit operator CountUsersRepositoryParams(FindManyUsersRequest request) =>
        new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = Parser.ToBoolOptional(request.Active),
        };
}