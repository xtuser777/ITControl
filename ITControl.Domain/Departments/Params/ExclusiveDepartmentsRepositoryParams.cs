using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record ExclusiveDepartmentsRepositoryParams :
    ExistsDepartmentsRepositoryParams, IExclusiveRepositoryParams
{
    public Guid ExcludeId { get; set; }
}
