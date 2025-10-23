using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Users.Params;

namespace ITControl.Communication.Users.Requests;

public record FindManyUsersRequest : FindManyRequest
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Active { get; set; }

    public static implicit operator FindManyUsersParams(
        FindManyUsersRequest request) =>
        new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = Parser.ToBoolOptional(request.Active),
        };

    public static implicit operator CountUsersParams(FindManyUsersRequest request) =>
        new()
        {
            Username = request.Username,
            Name = request.Name,
            Email = request.Email,
            Active = Parser.ToBoolOptional(request.Active),
        };
}