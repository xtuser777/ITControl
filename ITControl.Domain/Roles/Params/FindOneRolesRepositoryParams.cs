namespace ITControl.Domain.Roles.Params;

public record FindOneRolesRepositoryParams
{
    public Guid Id { get; set; }
    public IncludesRolesParams? Includes { get; set; } = null;

    public void Deconstruct(out Guid id, out IncludesRolesParams? includes)
    {
        id = Id;
        includes = Includes;
    }
}
