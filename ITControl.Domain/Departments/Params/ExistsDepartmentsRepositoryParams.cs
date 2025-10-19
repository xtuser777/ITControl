using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record ExistsDepartmentsRepositoryParams :
    CountDepartmentsRepositoryParams, IExistsRepositoryParams
{
}
