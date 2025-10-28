using ITControl.Application.Shared.Params;
using ITControl.Presentation.Calls.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record CreateCallsParams
{
    [FromBody]
    public CreateCallsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateCallsParams param) =>
        new()
        {
            Params = param.Request
        };
}