namespace ITControl.Domain.Divisions.Params;

public class FindManyDivisionsRepositoryParams
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByDepartment { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }

    public void Deconstruct(
        out string? name,
        out Guid? departmentId,
        out string? orderByName,
        out string? orderByDepartment,
        out int? page,
        out int? size)
    {
        name = Name;
        departmentId = DepartmentId;
        orderByName = OrderByName;
        orderByDepartment = OrderByDepartment;
        page = Page;
        size = Size;
    }

    public static implicit operator CountDivisionsRepositoryParams(FindManyDivisionsRepositoryParams @params)
        => new()
        {
            Name = @params.Name,
            DepartmentId = @params.DepartmentId
        };
}
