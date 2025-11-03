using ITControl.Application.Shared.Params;
using ITControl.Presentation.Positions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record UpdatePositionsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdatePositionsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdatePositionsParams paramsModel) =>
        new()
        {
            Id = paramsModel.Id,
            Props = paramsModel.Request
        };
}
