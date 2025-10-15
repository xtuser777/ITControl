using ITControl.Domain.Roles.Params;

namespace ITControl.Communication.Roles.Requests;

public record FindOneRolesRequest
{
    public Guid Id { get; set; }
    public bool? IncludeRolesPages { get; set; } = true;

    public static implicit operator FindOneRolesRepositoryParams(FindOneRolesRequest request) => new()
    {
        Id = request.Id,
        Includes = new IncludesRolesParams
        {
            RolesPages = new IncludesRolesPagesParams
            {
                Page = request.IncludeRolesPages ?? true
            }
        }
    };
}
