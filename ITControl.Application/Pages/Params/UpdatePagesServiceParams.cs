using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record UpdatePagesServiceParams
{
    public Guid Id { get; set; }
    public UpdatePageParams Params { get; set; } = new();

    public static implicit operator FindOnePagesServiceParams(
        UpdatePagesServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id
        };
}
