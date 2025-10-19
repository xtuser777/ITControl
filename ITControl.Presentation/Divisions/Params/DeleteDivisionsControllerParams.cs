using ITControl.Application.Divisions.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Divisions.Params;

public record DeleteDivisionsControllerParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteDivisionsServiceParams(DeleteDivisionsControllerParams @params)
        => new DeleteDivisionsServiceParams
        {
            Id = @params.Id
        };
}