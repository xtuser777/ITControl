using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record FindOneDepartmentsRepositoryParams : IFindOneRepositoryParams
{
    public Guid Id { get; init; }
}