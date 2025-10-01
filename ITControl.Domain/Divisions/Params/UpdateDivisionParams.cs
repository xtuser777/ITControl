namespace ITControl.Domain.Divisions.Params;

public class UpdateDivisionParams
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }

    public void Deconstruct(out string? name, out Guid? departmentId)
    {
        name = Name;
        departmentId = DepartmentId;
    }
}
