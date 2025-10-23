using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Roles.Params;

public record FindManyRolesParams : FindManyParams
{
    public string? Name { get; set; } = null;
    public bool? Active { get; set; } = null;
}
