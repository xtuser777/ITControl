namespace ITControl.Domain.Departments.Params;

public record CountDepartmentsRepositoryParams : 
    FindManyDepartmentsRepositoryParams
{
    public Guid? Id { get; set; }
}
