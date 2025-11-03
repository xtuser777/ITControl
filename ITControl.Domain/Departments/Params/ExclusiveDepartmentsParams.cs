namespace ITControl.Domain.Departments.Params;

public class ExclusiveDepartmentsParams :
    FindManyDepartmentsParams
{
    public Guid ExcludeId { get; set; }
}
