using ITControl.Domain.Positions.Params;

namespace ITControl.Application.Positions.Params;

public record FindOnePositionsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOnePositionRepositoryParams(
        FindOnePositionsServiceParams serviceParams) =>
        new() { Id = serviceParams.Id };
}
