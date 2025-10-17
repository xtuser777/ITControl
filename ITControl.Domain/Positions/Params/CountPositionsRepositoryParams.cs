using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public class CountPositionsRepositoryParams : FindManyPositionsRepositoryParams, ICountRepositoryParams
{
    public Guid? Id { get; set; } = null;
}