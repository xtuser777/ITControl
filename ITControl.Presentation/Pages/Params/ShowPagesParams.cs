using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Params;

public record ShowPagesParams
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowPagesParams request) 
        => new() { Id = request.Id };
}
