using ITControl.Application.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Roles.Params;

public record DeleteRolesParams
{
    [FromRoute] public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteRolesParams param)
        => new()
        {
            Id = param.Id,
        };
}