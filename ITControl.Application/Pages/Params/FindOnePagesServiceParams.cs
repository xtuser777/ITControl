using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record FindOnePagesServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOnePagesRepositoryParams(
        FindOnePagesServiceParams serviceParams) =>
        new()
        {
            Id = serviceParams.Id,
        };
}
