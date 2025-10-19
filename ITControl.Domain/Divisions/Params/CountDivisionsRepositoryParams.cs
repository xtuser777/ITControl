using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record CountDivisionsRepositoryParams : 
    FindManyDivisionsRepositoryParams, ICountRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
