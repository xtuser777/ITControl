using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Roles.Params;

namespace ITControl.Communication.Roles.Requests;

public record FindManyRolesRequest : FindManyRequest
{
    public string? Name { get; set; }
    public string? Active { get; set; }

    public static implicit operator FindManyRolesParams(
        FindManyRolesRequest request) => new()
    {
        Name = request.Name,
        Active = Parser.ToBoolOptional(request.Active)
    };

    public static implicit operator CountRolesParams(
        FindManyRolesRequest request) => new()
    {
        Name = request.Name,
        Active = Parser.ToBoolOptional(request.Active)
    };
}