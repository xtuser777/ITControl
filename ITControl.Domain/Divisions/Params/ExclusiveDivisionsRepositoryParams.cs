using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record ExclusiveDivisionsRepositoryParams :
    FindManyDivisionsRepositoryParams, IExclusiveRepositoryParams
{
    public Guid ExcludeId { get; set; }
}
