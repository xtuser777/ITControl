using ITControl.Application.Divisions.Params;
using ITControl.Communication.Divisions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record CreateDivisionsControllerParams
{
    [FromBody]
    public CreateDivisionsRequest Request { get; set; } = null!;

    public static implicit operator CreateDivisionsServiceParams(
        CreateDivisionsControllerParams param)
        => new ()
        {
            Params = param.Request,
        };
}