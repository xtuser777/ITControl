namespace ITControl.Domain.Divisions.Params;

public class ExclusiveDivisionsRepositoryParams
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public void Deconstruct(out Guid id, out string? name)
    {
        id = Id;
        name = Name;
    }
}
