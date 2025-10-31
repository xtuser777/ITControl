using ITControl.Application.Shared.Params;
using ITControl.Presentation.Pages.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record UpdatePagesParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
    
    [FromBody]
    public UpdatePagesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdatePagesParams paramsModel) =>
        new()
        {
            Id = paramsModel.Id,
            Props = paramsModel.Request,
        };
}
