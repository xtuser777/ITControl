using ITControl.Domain.Departments.Params;

namespace ITControl.Application.Departments.Params;

public record FindManyPaginationDepartmentsServiceParams
{
    public CountDepartmentsRepositoryParams CountParams { get; set; } = null!;
    public string? Page { get; set; } = null;
    public string? Size { get; set; } = null;
}
