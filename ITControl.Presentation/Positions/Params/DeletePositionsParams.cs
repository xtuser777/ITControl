using ITControl.Application.Positions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record DeletePositionsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeletePositionsServiceParams(
        DeletePositionsParams presentationParams) =>
        new() { Id = presentationParams.Id };
}
