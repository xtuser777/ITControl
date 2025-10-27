using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record DeletePagesParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
            DeletePagesParams paramsModel) =>
            new()
            {
                Id = paramsModel.Id,
            };
}
