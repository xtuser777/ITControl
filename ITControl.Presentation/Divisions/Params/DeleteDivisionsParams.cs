using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record DeleteDivisionsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteDivisionsParams @params)
        => new ()
        {
            Id = @params.Id
        };
}