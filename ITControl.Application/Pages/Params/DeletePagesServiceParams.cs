namespace ITControl.Application.Pages.Params;

public record DeletePagesServiceParams
{
    public Guid Id { get; init; }

    public static implicit operator FindOnePagesServiceParams(
        DeletePagesServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id,
        };
}
