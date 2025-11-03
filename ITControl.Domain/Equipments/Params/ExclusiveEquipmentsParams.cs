namespace ITControl.Domain.Equipments.Params;

public class ExclusiveEquipmentsParams : 
    FindManyEquipmentsParams
{
    public Guid ExcludeId { get; set; }
}
