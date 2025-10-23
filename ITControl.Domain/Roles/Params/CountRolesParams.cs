namespace ITControl.Domain.Roles.Params;

public record CountRolesParams : FindManyRolesParams
{
    public Guid? Id { get; set; } = null;
}
