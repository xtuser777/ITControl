namespace ITControl.Domain.Departments.Params;

public class ExistsDepartmentsRepositoryParams
{
    public Guid? Id { get; set; }
    public string? Alias { get; set; }
    public string? Name { get; set; }

    public void Deconstruct(out Guid? id, out string? alias, out string? name)
    {
        id = Id;
        alias = Alias;
        name = Name;
    }
}
