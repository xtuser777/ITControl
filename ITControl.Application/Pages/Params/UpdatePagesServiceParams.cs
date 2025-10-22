using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record UpdatePagesServiceParams
{
    public Guid Id { get; init; }
    public UpdatePageParams Params { get; init; } = new();

    public static implicit operator FindOnePagesServiceParams(
        UpdatePagesServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id
        };
}
