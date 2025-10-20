using ITControl.Domain.Positions.Params;

namespace ITControl.Application.Positions.Params;

public record UpdatePositionsServiceParams
{
    public Guid Id { get; set; }
    public UpdatePositionParams Params { get; set; } = new();

    public static implicit operator FindOnePositionsServiceParams(
        UpdatePositionsServiceParams serviceParams) =>
        new() { Id = serviceParams.Id };
}
