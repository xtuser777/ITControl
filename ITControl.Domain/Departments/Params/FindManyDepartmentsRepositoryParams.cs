namespace ITControl.Domain.Departments.Params;

public class FindManyDepartmentsRepositoryParams
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
    public string? OrderByAlias { get; set; }
    public string? OrderByName { get; set; }
    public int? Page { get; set; }
    public int? Size { get; set; }

    public void Deconstruct(out string? alias, out string? name, out string? orderByAlias, out string? orderByName, out int? page, out int? size)
    {
        alias = Alias;
        name = Name;
        orderByAlias = OrderByAlias;
        orderByName = OrderByName;
        page = Page;
        size = Size;
    }

    public static implicit operator CountDepartmentsRepositoryParams(FindManyDepartmentsRepositoryParams @params)
    {
        var (alias, name, _, _, _, _) = @params;
        return new CountDepartmentsRepositoryParams
        {
            Alias = alias,
            Name = name
        };
    }
}
