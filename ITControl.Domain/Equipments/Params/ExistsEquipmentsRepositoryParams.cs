using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Params;

public record ExistsEquipmentsRepositoryParams : 
    CountEquipmentsRepositoryParams, IExistsRepositoryParams
{
}
