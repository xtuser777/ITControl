using ITControl.Application.Shared.Params;
using ITControl.Presentation.Calls.Requests;
using ITControl.Presentation.Shared.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record CreateCallsParams
{
    [FromBody]
    public CreateCallsRequest Request { get; set; } = new();

    [ModelBinder(BinderType = typeof(UserIdAttribute))]
    public Guid UserId { get; set; }

    public static implicit operator CreateServiceParams(
        CreateCallsParams param) =>
        new()
        {
            Props = param.Request
        };
}