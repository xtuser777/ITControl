using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record ExistsPositionsRepositoryParams : 
    CountPositionsRepositoryParams, IExistsRepositoryParams
{
}