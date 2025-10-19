using ITControl.Domain.Roles.Params;

namespace ITControl.Communication.Roles.Requests;

public record OrderByRolesRequest
{
    public string? Name { get; set; }
    public string? Active { get; set; }

    public static implicit operator OrderByRolesRepositoryParams(OrderByRolesRequest request) => new()
    {
        Name = request.Name,
        Active = request.Active
    };
}