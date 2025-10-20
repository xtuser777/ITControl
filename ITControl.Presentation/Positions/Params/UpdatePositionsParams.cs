using ITControl.Application.Positions.Params;
using ITControl.Communication.Positions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record UpdatePositionsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdatePositionsRequest Request { get; set; } = new();

    public static implicit operator UpdatePositionsServiceParams(
        UpdatePositionsParams paramsModel) =>
        new()
        {
            Id = paramsModel.Id,
            Params = paramsModel.Request
        };
}
