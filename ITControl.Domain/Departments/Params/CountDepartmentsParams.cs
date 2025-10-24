namespace ITControl.Domain.Departments.Params;

public record CountDepartmentsParams : 
    FindManyDepartmentsParams
{
    public Guid? Id { get; set; }
}
