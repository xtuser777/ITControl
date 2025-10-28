using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record UpdateDivisionParams : UpdateEntityParams
{
    public string? Name { get; init; } = null;
    public Guid? DepartmentId { get; init; } = null;

    public void Deconstruct(out string? name, out Guid? departmentId)
    {
        name = Name;
        departmentId = DepartmentId;
    }
}
