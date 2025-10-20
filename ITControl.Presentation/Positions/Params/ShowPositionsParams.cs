using ITControl.Application.Positions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record ShowPositionsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOnePositionsServiceParams(
        ShowPositionsParams showParams) =>
        new() { Id = showParams.Id };
}
