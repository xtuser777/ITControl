namespace ITControl.Domain.Roles.Params;

public record CountRolesRepositoryParams : FindManyRolesRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
