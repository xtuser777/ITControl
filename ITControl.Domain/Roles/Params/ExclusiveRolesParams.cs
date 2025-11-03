namespace ITControl.Domain.Roles.Params;

public class ExclusiveRolesParams : FindManyRolesParams
{
    public Guid ExcludeId { get; set; }
}
