using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Users.Params;

public record IncludesUsersParams : IncludesParams
{
    public bool? Position { get; init; }
    public bool? Role { get; init; }
    public bool? Unit { get; init; }
    public bool? Department { get; init; }
    public bool? Division { get; init; }
    public bool? UsersEquipments { get; set; }
    public bool? UsersSystems { get; set; }
}