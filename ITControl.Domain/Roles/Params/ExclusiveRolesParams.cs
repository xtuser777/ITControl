namespace ITControl.Domain.Roles.Params;

public record ExclusiveRolesParams : FindManyRolesParams
{
    public Guid ExcludeId { get; set; }
}
