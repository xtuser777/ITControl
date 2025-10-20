using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record ExclusivePositionsRepositoryParams 
    : FindManyPositionsRepositoryParams, IExclusiveRepositoryParams
{
    public Guid ExcludeId { get; set; }
}