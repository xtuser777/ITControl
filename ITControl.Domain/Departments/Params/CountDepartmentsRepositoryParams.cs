using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record CountDepartmentsRepositoryParams : 
    FindManyDepartmentsRepositoryParams, ICountRepositoryParams
{
    public Guid? Id { get; set; }
}
