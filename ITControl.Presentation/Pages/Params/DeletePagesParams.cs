using ITControl.Application.Pages.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record DeletePagesParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator DeletePagesServiceParams(
            DeletePagesParams paramsModel) =>
            new()
            {
                Id = paramsModel.Id,
            };
}
