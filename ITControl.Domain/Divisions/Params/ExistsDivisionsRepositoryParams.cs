using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record ExistsDivisionsRepositoryParams : 
    CountDivisionsRepositoryParams, IExistsRepositoryParams
{
}
