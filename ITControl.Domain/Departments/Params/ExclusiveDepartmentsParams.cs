namespace ITControl.Domain.Departments.Params;

public record ExclusiveDepartmentsParams :
    FindManyDepartmentsParams
{
    public Guid ExcludeId { get; set; }
}
