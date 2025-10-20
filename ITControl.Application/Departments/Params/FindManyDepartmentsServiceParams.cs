using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Departments.Params;

public record FindManyDepartmentsServiceParams
{
    public FindManyDepartmentsRepositoryParams FindManyParams { get; set; } = null!;
    public OrderByDepartmentsRepositoryParams OrderByParams { get; set; } = null!;
    public PaginationParams PaginationParams { get; set; } = null!;
}
