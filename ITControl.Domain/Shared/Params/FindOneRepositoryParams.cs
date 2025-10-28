namespace ITControl.Domain.Shared.Params;

public record FindOneRepositoryParams
{
    public Guid Id { get; set; }
    public IncludesParams? Includes { get; set; }

    public void Deconstruct(out Guid id, out IncludesParams? includes)
    {
        id = Id;
        includes = Includes;
    }
}