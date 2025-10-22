using ITControl.Application.Supplements.Params;
using ITControl.Communication.Supplements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record CreateSupplementsParams
{
    [FromBody]
    public CreateSupplementsRequest Request { get; set; } = new();

    public static implicit operator CreateSupplementsServiceParams(
        CreateSupplementsParams param)
        => new()
        {
            Params = param.Request
        };
}