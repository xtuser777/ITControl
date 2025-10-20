namespace ITControl.Application.Positions.Params;

public record DeletePositionsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOnePositionsServiceParams(
        DeletePositionsServiceParams serviceParams) =>
        new() { Id = serviceParams.Id };
}
