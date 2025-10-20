using ITControl.Application.Positions.Params;
using ITControl.Communication.Positions.Requests;

namespace ITControl.Presentation.Positions.Params;

public record CreatePositionsParams
{
    public CreatePositionsRequest Request { get; set; } = new();

    public static implicit operator CreatePositionsServiceParams(
        CreatePositionsParams paramsModel) =>
        new() { Params = paramsModel.Request };
}
