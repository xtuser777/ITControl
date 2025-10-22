using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record FindOnePagesServiceParams
{
    public Guid Id { get; init; }

    public static implicit operator FindOnePagesRepositoryParams(
        FindOnePagesServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id,
        };
}
