using ITControl.Communication.Shared.Requests;
using ITControl.Communication.Shared.Utils;
using ITControl.Domain.Roles.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Communication.Roles.Requests;

public record FindManyRolesRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? Active { get; set; }

    public static implicit operator FindManyRolesRepositoryParams(FindManyRolesRequest request) => new()
    {
        Name = request.Name,
        Active = Parser.ToBoolOptional(request.Active)
    };

    public static implicit operator CountRolesRepositoryParams(FindManyRolesRequest request) => new()
    {
        Name = request.Name,
        Active = Parser.ToBoolOptional(request.Active)
    };

    public static implicit operator PaginationParams(FindManyRolesRequest request) => new()
    {
        Page = Parser.ToIntOptional(request.Page),
        Size = Parser.ToIntOptional(request.Size)
    };
}