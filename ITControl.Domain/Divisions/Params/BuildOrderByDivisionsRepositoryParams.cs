namespace ITControl.Domain.Divisions.Params;

public class BuildOrderByDivisionsRepositoryParams
{
    public IQueryable<Entities.Division> Query { get; set; } = null!;
    public string? OrderByName { get; set; }
    public string? OrderByDepartment { get; set; }

    public void Deconstruct(
        out IQueryable<Entities.Division> query,
        out string? orderByName,
        out string? orderByDepartment)
    {
        query = Query;
        orderByName = OrderByName;
        orderByDepartment = OrderByDepartment;
    }
}
