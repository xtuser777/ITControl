namespace ITControl.Domain.Equipments.Params;

public record ExclusiveEquipmentsRepositoryParams : 
    FindManyEquipmentsRepositoryParams
{
    public Guid ExcludeId { get; set; }
}
