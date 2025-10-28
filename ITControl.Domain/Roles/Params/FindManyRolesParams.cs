using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Roles.Params;

public record FindManyRolesParams : FindManyParams
{
    public string? Name { get; set; }
    public bool? Active { get; set; }
}
