using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record OrderByDepartmentsRepositoryParams : OrderByRepositoryParams
{
    public string? Alias { get; set; } = null;
    public string? Name { get; set; } = null;
}
