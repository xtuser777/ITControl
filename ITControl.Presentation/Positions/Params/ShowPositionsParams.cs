using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record ShowPositionsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowPositionsParams showParams) =>
        new() { Id = showParams.Id };
}
