namespace ITControl.Domain.Equipments.Params;

public record CountEquipmentsRepositoryParams : FindManyEquipmentsRepositoryParams
{
    public Guid? Id { get; set; } = null;
}