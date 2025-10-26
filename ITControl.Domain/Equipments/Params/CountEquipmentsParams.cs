namespace ITControl.Domain.Equipments.Params;

public record CountEquipmentsParams : 
    FindManyEquipmentsParams
{
    public Guid? Id { get; init; }
}