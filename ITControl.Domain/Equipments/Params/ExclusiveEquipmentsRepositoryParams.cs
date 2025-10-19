using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Params;

public record ExclusiveEquipmentsRepositoryParams : 
    FindManyEquipmentsRepositoryParams, IExclusiveRepositoryParams
{
    public Guid ExcludeId { get; set; }
}
