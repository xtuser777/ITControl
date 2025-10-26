namespace ITControl.Domain.Equipments.Params;

public record ExclusiveEquipmentsParams : 
    FindManyEquipmentsParams
{
    public Guid ExcludeId { get; set; }
}
