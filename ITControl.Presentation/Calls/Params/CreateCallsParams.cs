using ITControl.Application.Calls.Params;
using ITControl.Communication.Calls.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record CreateCallsParams
{
    [FromBody]
    public CreateCallsRequest Request { get; set; } = new();

    public static implicit operator CreateCallsServiceParams(CreateCallsParams param) =>
        new CreateCallsServiceParams
        {
            Params = param.Request
        };
}