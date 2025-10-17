using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public class ExclusivePositionsRepositoryParams 
    : ExistsPositionsRepositoryParams, IExclusiveRepositoryParams
{
    public Guid ExcludeId { get; set; }
}