using ITControl.Application.Pages.Params;
using ITControl.Communication.Pages.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record CreatePagesParams
{
    [FromBody]
    public CreatePagesRequest Request { get; init; } = new();

    public static implicit operator CreatePagesServiceParams
        (CreatePagesParams paramsModel) =>
        new()
        {
            Params = paramsModel.Request
        };
}
