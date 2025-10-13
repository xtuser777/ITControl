namespace ITControl.Domain.Equipments.Params;

public record FindOneEquipmentsRepositoryParams
{
    public Guid Id { get; set; }
    public bool? IncludeContract { get; set; } = null;

    public void Deconstruct(out Guid id, out bool? includeContract)
    {
        id = Id;
        includeContract = IncludeContract;
    }
}
