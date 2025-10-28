using ITControl.Application.Shared.Params;
using ITControl.Presentation.Pages.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record CreatePagesParams
{
    [FromBody]
    public CreatePagesRequest Request { get; init; } = new();

    public static implicit operator CreateServiceParams
        (CreatePagesParams paramsModel) =>
        new()
        {
            Params = paramsModel.Request
        };
}
