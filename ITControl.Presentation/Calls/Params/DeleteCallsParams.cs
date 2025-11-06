using ITControl.Application.Shared.Params;
using ITControl.Presentation.Shared.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record DeleteCallsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [ModelBinder(BinderType = typeof(UserIdAttribute))]
    public Guid UserId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteCallsParams param)
        => new ()
        {
            Id = param.Id,
        };
}