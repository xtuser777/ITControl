using ITControl.Application.Shared.Params;
using ITControl.Presentation.Divisions.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record CreateDivisionsParams
{
    [FromBody]
    public CreateDivisionsRequest Request { get; set; } = null!;

    public static implicit operator CreateServiceParams(
        CreateDivisionsParams param)
        => new ()
        {
            Params = param.Request,
        };
}