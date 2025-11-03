using ITControl.Application.Shared.Params;
using ITControl.Presentation.Supplements.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements.Params;

public record CreateSupplementsParams
{
    [FromBody]
    public CreateSupplementsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateSupplementsParams param)
        => new()
        {
            Props = param.Request
        };
}