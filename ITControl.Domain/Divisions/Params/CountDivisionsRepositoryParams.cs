namespace ITControl.Domain.Divisions.Params;

public class CountDivisionsRepositoryParams
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
    
    public void Deconstruct(out Guid? id, out string? name, out Guid? departmentId)
    {
        id = Id;
        name = Name;
        departmentId = DepartmentId;
    }
}
