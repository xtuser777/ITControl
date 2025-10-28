using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Roles.Params;

public record OrderByRolesParams : OrderByParams
{
    public string? Name { get; set; } = null;
    public string? Active { get; set; } = null;
}
