using ITControl.Domain.Divisions.Entities;

namespace ITControl.Domain.Divisions.Params;

public class BuildQueryDivisionsRepositoryParams
{
    public IQueryable<Division> Query { get; set; } = null!;
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }

    public void Deconstruct(out IQueryable<Division> query, out Guid? id, out string? name, out Guid? departmentId)
    {
        query = Query;
        id = Id;
        name = Name;
        departmentId = DepartmentId;
    }
}
