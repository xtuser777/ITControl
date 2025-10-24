using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Departments.Params;

public record FindManyDepartmentsParams : FindManyParams
{
    public string? Alias { get; set; } = null;
    public string? Name { get; set; } = null;
}
