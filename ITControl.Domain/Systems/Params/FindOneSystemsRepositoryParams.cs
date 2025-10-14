namespace ITControl.Domain.Systems.Params;

public record FindOneSystemsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeContract { get; set; } = null;

    public void Deconstruct(out Guid id, out bool? includeContract)
    {
        id = Id;
        includeContract = IncludeContract;
    }
}
