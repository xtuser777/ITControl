using ITControl.Application.Calls.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Calls.Params;

public record DeleteCallsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteCallsServiceParams(
        DeleteCallsParams param)
        => new DeleteCallsServiceParams
        {
            Id = param.Id,
        };
}