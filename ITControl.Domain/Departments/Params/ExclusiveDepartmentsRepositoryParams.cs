namespace ITControl.Domain.Departments.Params;

public record ExclusiveDepartmentsRepositoryParams :
    FindManyDepartmentsRepositoryParams
{
    public Guid ExcludeId { get; set; }
}
