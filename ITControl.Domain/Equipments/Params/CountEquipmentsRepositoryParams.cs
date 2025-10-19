using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Params;

public record CountEquipmentsRepositoryParams : 
    FindManyEquipmentsRepositoryParams, ICountRepositoryParams
{
    public Guid? Id { get; init; } = null;
}