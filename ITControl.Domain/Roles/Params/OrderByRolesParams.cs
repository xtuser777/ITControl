using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Roles.Params;

public record OrderByRolesParams : OrderByParams
{
    public string? Name { get; set; } = null;
    public string? Active { get; set; } = null;
}
