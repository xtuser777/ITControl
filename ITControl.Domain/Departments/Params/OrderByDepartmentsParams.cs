using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Departments.Params;

public record OrderByDepartmentsParams : OrderByParams
{
    public string? Alias { get; set; } = null;
    public string? Name { get; set; } = null;
}
