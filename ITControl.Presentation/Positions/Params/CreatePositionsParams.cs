using ITControl.Application.Shared.Params;
using ITControl.Communication.Positions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Positions.Params;

public record CreatePositionsParams
{
    [FromBody]
    public CreatePositionsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreatePositionsParams paramsModel) =>
        new() { Params = paramsModel.Request };
}
