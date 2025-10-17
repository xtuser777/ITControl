using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public class FindOnePositionRepositoryParams : IFindOneRepositoryParams
{
    public Guid Id { get; set; }
}