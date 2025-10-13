namespace ITControl.Domain.Equipments.Params;

public record ExclusiveEquipmentsRepositoryParams: FindManyEquipmentsRepositoryParams
{
    public Guid Id { get; set; }
}
